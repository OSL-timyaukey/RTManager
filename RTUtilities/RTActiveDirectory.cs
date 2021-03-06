﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using AD = System.DirectoryServices;

namespace RTUtilities
{
    public static class RTActiveDirectory
    {
        private static List<string> _ITPersonNames = null;
        private static List<string> _ITEmailAddresses = null;
        private static List<string> _AllEmailAddresses = null;

        private const string _CacheFileName = "ActiveDirectoryCache.txt";
        private static Semaphore _AccessLock;

        //Not currently using this, but it works and I may want to switch
        //to picking email address by selecting name from list so I
        //will not delete this (yet).
        public static IEnumerable<string> ITPersonNames
        {
            get
            {
                // This semaphore will block until the background thread that 
                // calls Load() is done.
                _AccessLock.WaitOne();
                _AccessLock.Release();
                return _ITPersonNames;
            }
        }

        public static IEnumerable<string> ITEmailAddresses
        {
            get
            {
                // This semaphore will block until the background thread that 
                // calls Load() is done.
                _AccessLock.WaitOne();
                _AccessLock.Release();
                return _ITEmailAddresses;
            }
        }

        public static IEnumerable<string> AllEmailAddresses
        {
            get
            {
                // This semaphore will block until the background thread that 
                // calls Load() is done.
                _AccessLock.WaitOne();
                _AccessLock.Release();
                return _AllEmailAddresses;
            }
        }

        public static void LoadInBackground()
        {
            // Other threads will block when calling the accessor properties
            // above until Load() releases this Semaphore() as its last step.
            _AccessLock = new Semaphore(0, 1);
            ThreadPool.QueueUserWorkItem(Load);
        }

        private static void Load(object dummy)
        {
            _ITPersonNames = new List<string>();
            _ITEmailAddresses = new List<string>();
            _AllEmailAddresses = new List<string>();
            // Reload the cache file from Active Directory every 4 hours,
            // or if the file does not exist.
            string cacheFullName = RTSettings.GetConfigFilePath(_CacheFileName);
            FileInfo cacheFile = new FileInfo(cacheFullName);
            if (cacheFile.Exists && DateTime.UtcNow.Subtract(cacheFile.LastWriteTimeUtc).TotalHours <= 4)
            {
                LoadFromFile(cacheFullName);
            }
            else
            {
                LoadFromActiveDirectory();
                SaveToFile(cacheFullName);
            }
            // Could add extra elements to any of these collections here,
            // for example email addresses of external partners or from
            // a personal profile.
            _ITPersonNames.Sort();
            _ITEmailAddresses.Sort();
            _AllEmailAddresses.Sort();
            // Release the lock so other threads can access this data.
            _AccessLock.Release();
        }

        private static void LoadFromFile(string cacheFullName)
        {
            using (TextReader cacheReader = new StreamReader(cacheFullName))
            {
                string cacheLine;
                // Load _ITPersonNames until blank line
                for (;;)
                {
                    cacheLine = cacheReader.ReadLine();
                    if (string.IsNullOrEmpty(cacheLine))
                        break;
                    _ITPersonNames.Add(cacheLine);
                }
                // Load _ITEmailAddresses until blank line
                for (;;)
                {
                    cacheLine = cacheReader.ReadLine();
                    if (string.IsNullOrEmpty(cacheLine))
                        break;
                    _ITEmailAddresses.Add(cacheLine);
                }
                // Load _AllEmailAddresses until blank line
                for (;;)
                {
                    cacheLine = cacheReader.ReadLine();
                    if (string.IsNullOrEmpty(cacheLine))
                        break;
                    _AllEmailAddresses.Add(cacheLine);
                }
            }
        }

        private static void SaveToFile(string cacheFullName)
        {
            using (TextWriter cacheWriter = new StreamWriter(cacheFullName))
            {
                foreach(string cacheLine in _ITPersonNames)
                {
                    cacheWriter.WriteLine(cacheLine);
                }
                cacheWriter.WriteLine();
                foreach (string cacheLine in _ITEmailAddresses)
                {
                    cacheWriter.WriteLine(cacheLine);
                }
                cacheWriter.WriteLine();
                foreach (string cacheLine in _AllEmailAddresses)
                {
                    cacheWriter.WriteLine(cacheLine);
                }
                cacheWriter.WriteLine();
            }
        }

        private static void LoadFromActiveDirectory()
        {
            string domainName = "LDAP://ou=osl,dc=win,dc=lottery,dc=state,dc=or,dc=us";
            AD.DirectoryEntry dirEntry = new AD.DirectoryEntry();
            AD.DirectorySearcher searcher;
            dirEntry.Path = domainName;
            dirEntry.AuthenticationType = AD.AuthenticationTypes.Secure;
            searcher = new AD.DirectorySearcher();
            searcher.SearchRoot = dirEntry;
            searcher.SearchScope = AD.SearchScope.Subtree;
            //searcher.Filter = "(&(objectCategory=person)(sAMAccountName=*))";
            searcher.Filter = "(&(objectCategory=person))";
            AD.SearchResultCollection results = searcher.FindAll();
            foreach (AD.SearchResult sr in results)
            {
                string adName = "";
                string adDepartment = "";
                string employeeId = "";
                string emailaddr = "";
                AD.ResultPropertyValueCollection departments = sr.Properties["department"];
                if (departments != null && departments.Count > 0)
                {
                    adDepartment = departments[0].ToString();
                }
                AD.ResultPropertyValueCollection employeeIds = sr.Properties["employeeid"];
                if (employeeIds != null && employeeIds.Count > 0)
                {
                    employeeId = (string)employeeIds[0];
                }
                AD.ResultPropertyValueCollection names = sr.Properties["Name"];
                if (names != null && names.Count > 0)
                {
                    adName = (string)names[0];
                }
                if (!string.IsNullOrEmpty(adName) && !string.IsNullOrEmpty(adDepartment))
          // Some non-security lottery staff do NOT have employee ID in Active Directory!
          // ALL OSP staff do NOT have an employee ID.
          //          (
          //          !string.IsNullOrEmpty(employeeId) || (adDepartment.ToLower() == "security")
          //          )
          //         )
                {
                    if (!adName.ToLower().Contains("-adm"))
                    {
                        AD.ResultPropertyValueCollection emails = sr.Properties["mail"];
                        if (emails != null && emails.Count > 0)
                        {
                            emailaddr = (string)emails[0];
                        }
                        if (!string.IsNullOrEmpty(adName))
                        {
                            if (adDepartment.ToLower() == "information technology" || adDepartment.StartsWith("IT"))
                            {
                                _ITPersonNames.Add(adName);
                                if (!string.IsNullOrEmpty(emailaddr))
                                    _ITEmailAddresses.Add(emailaddr);
                            }
                        }
                        if (!string.IsNullOrEmpty(emailaddr))
                            _AllEmailAddresses.Add(emailaddr);
                    }
                }
            }
        }
    }
}
