using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace RTUtilities
{
    public class RTEmail
    {
        [RTSuppress]
        [Browsable(false)]
        public int TicketNumber { get; set; }
        
        #region Basic Properties

        [Category("Basic")]
        public string Subject { get; set; }

        [Category("Basic")]
        [DisplayName("Queue Name")]
        [RTChoiceLoader(typeof(RTChoiceLoaderQueue))]
        [TypeConverter(typeof(RTDropDownConverter))]
        [RTFieldName("Queue")]
        public string QueueName { get; set; }

        [Category("Basic")]
        [RTChoices("new|open|stalled|InApproval|resolved|rejected")]
        [TypeConverter(typeof(RTDropDownConverter))]
        public string Status { get; set; }

        [Category("Basic")]
        public int Priority { get; set; }

        #endregion

        #region People Properties

        [Category("People")]
        [DisplayName("Owner Email")]
        [RTChoiceLoader(typeof(RTChoiceLoaderITEmailAddresses))]
        [TypeConverter(typeof(RTDropDownConverter))]
        public string Owner { get; set; }

        [Category("People")]
        [DisplayName("Requestor Email")]
        [Description("You may type in a requestor email address that is not in the drop-down list")]
        [TypeConverter(typeof(RTDropDownConverterOpen))]
        [RTChoiceLoader(typeof(RTChoiceLoaderAllEmailAddresses))]
        public string Requestor { get; set; }

        #endregion

        #region Classification Properties

        [Category("Classification")]
        [DisplayName("Ticket Type")]
        [RTChoices("Incident|Change|Problem|Release|Service Request")]
        [RTFieldName("CF.{Ticket Type}")]
        [TypeConverter(typeof(RTDropDownConverter))]
        public string TicketType { get; set; }

        [Category("Classification")]
        [DisplayName("Change Type")]
        [RTChoiceLoader(typeof(RTChoiceLoaderChangeType))]
        [RTFieldName("CF.{Change Type}")]
        [TypeConverter(typeof(RTDropDownConverter))]
        public string ChangeType { get; set; }

        [Category("Classification")]
        [RTChoices("|IT Projects|Service Enhancements|Enterprise Projects|Production Support|Miscellaneous Admin")]
        [TypeConverter(typeof(RTDropDownConverter))]
        [RTFieldName("CF.{Activity}")]
        public string Activity { get; set; }

        [Category("Classification")]
        [DisplayName("Sub Activity")]
        [RTChoiceLoader(typeof(RTChoiceLoaderSubActivity))]
        [TypeConverter(typeof(RTDropDownConverter))]
        // Yes, that's "Catagory" and not "Category".
        [RTFieldName("CF.{Activity Sub-Catagory}")]
        public string SubActivity { get; set; }

        [Category("Classification")]
        [RTChoices("|Data Conversion|Software Coding and Configuration|Software Design and Requirements Development|Software Interfaces and Installation to Hardware|Testing|NA")]
        [TypeConverter(typeof(RTDropDownConverter))]
        [DisplayName("GASB 51")]
        [RTFieldName("CF.{GASB 51}")]
        public string ActivityType { get; set; }

        #endregion

        #region OSL Prioritization Properties

        [Category("OSL Prioritization")]
        [RTChoices("1 - High|2 - Medium|3 - Low")]
        [RTFieldName("CF.{Impact}")]
        [TypeConverter(typeof(RTDropDownConverter))]
        public string Impact { get; set; }

        [Category("OSL Prioritization")]
        // The two spaces before "(Critically Blocked)" are important - it is named that way.
        [RTChoices("1 - High  (Critically Blocked)|2 - Medium (Non-Critically Blocked)|3 - Low")]
        [RTFieldName("CF.{Urgency}")]
        [TypeConverter(typeof(RTDropDownConverter))]
        public string Urgency { get; set; }

        [Category("OSL Prioritization")]
        [DisplayName("Priority")]
        [RTChoices("1 - Critical|2 - High|3 - Medium|4 - Low")]
        [RTFieldName("CF.{Priority}")]
        [TypeConverter(typeof(RTDropDownConverter))]
        public string CustomPriority { get; set; }

        #endregion

        #region Scheduling Properties

        [Category("Scheduling")]
        [DisplayName("Estimated Minutes")]
        public int TimeEstimated { get; set; }

        [Category("Scheduling")]
        [DisplayName("Worked Minutes")]
        public int TimeWorked { get; set; }

        [Category("Scheduling")]
        [DisplayName("Remaining Minutes")]
        public int TimeLeft { get; set; }

        [Category("Scheduling")]
        [DisplayName("Due Date")]
        [RTFieldName("Due")]
        [Description("Enter \"1/1/1900\" to use today's date")]
        // Dates must be formatted as "yyyy-mm-dd hh:mm:ss" in the email, where the time is optional
        public DateTime DueDate { get; set; }

        [Category("Scheduling")]
        [DisplayName("Starts Date")]
        [RTFieldName("Starts")]
        [Description("Enter \"1/1/1900\" to use today's date")]
        public DateTime StartsDate { get; set; }

        [Category("Scheduling")]
        [DisplayName("Started Date")]
        [RTFieldName("Started")]
        [Description("Enter \"1/1/1900\" to use today's date")]
        public DateTime StartedDate { get; set; }

        #endregion

        public string Validate()
        {
            if (string.IsNullOrEmpty(Subject))
                return "Subject is required.";
            if (string.IsNullOrEmpty(QueueName))
                return "Queue name is required.";
            if (TicketType == "Change")
            {
                if (string.IsNullOrEmpty(ChangeType))
                    return "Change type is required for change tickets";
            }
            if (string.IsNullOrEmpty(Status))
                return "Ticket status is required.";
            if (string.IsNullOrEmpty(TicketType))
                return "Ticket type is required.";
            if (string.IsNullOrEmpty(Owner))
                return "Owner email address is required.";
            if (string.IsNullOrEmpty(Requestor))
                return "Requestor email address is required.";
            if (string.IsNullOrEmpty(CustomPriority))
                return "OSL Priority is required.";
            if (string.IsNullOrEmpty(Impact))
                return "OSL Impact is required.";
            if (string.IsNullOrEmpty(Urgency))
                return "OSL Urgency is required.";
            return null;
        }

        [RTSuppress]
        [Browsable(false)]
        public string UpdateMessage
        {
            get
            {
                return IterateProperties();
            }
        }

        [RTSuppress]
        [Browsable(false)]
        public string CreateMessage
        {
            get
            {
                return IterateProperties();
            }
        }

        private string IterateProperties()
        {
            StringBuilder output = new StringBuilder();
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.GetCustomAttribute(typeof(RTSuppressAttribute)) == null)
                {
                    string rtFieldName = property.Name;
                    RTFieldNameAttribute fieldNameAttribute = (RTFieldNameAttribute)property.GetCustomAttribute(typeof(RTFieldNameAttribute));
                    if (fieldNameAttribute != null)
                    {
                        rtFieldName = fieldNameAttribute.Value;
                    }
                    object propertyValue = property.GetValue(this, null);
                    string propertyFormatted;
                    bool hasValue = false;
                    if (propertyValue != null)
                    {
                        if (propertyValue is string)
                        {
                            hasValue = !String.IsNullOrEmpty((string)propertyValue);
                            propertyFormatted = (string)propertyValue;
                        }
                        else if (propertyValue is int)
                        {
                            hasValue = (int)propertyValue != 0;
                            propertyFormatted = propertyValue.ToString();
                        }
                        else if (propertyValue is DateTime)
                        {
                            hasValue = ((DateTime)propertyValue).Ticks != 0L;
                            propertyFormatted = ((DateTime)propertyValue).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                            throw new InvalidOperationException("Unsupported property type");
                        if (hasValue)
                        {
                            output.Append(rtFieldName + ": " + propertyFormatted + "\n");
                        }
                    }
                }
            }
            return output.ToString();
        }
    }
}
