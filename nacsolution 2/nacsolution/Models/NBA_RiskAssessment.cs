//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nacsolution.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NBA_RiskAssessment
    {
        public int RISK_ID { get; set; }
        public Nullable<int> QUESTION_ID { get; set; }
        public Nullable<int> ANSWER_ID { get; set; }
        public string risk_description { get; set; }
        public string classification { get; set; }
        public Nullable<int> SERVICE_PLAN_ID { get; set; }
        public Nullable<int> SYS_USER_ID { get; set; }
        public Nullable<int> SELF_ASSESS_ID { get; set; }
    }
}
