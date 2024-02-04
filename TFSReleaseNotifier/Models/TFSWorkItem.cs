using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFSReleaseNotifier.Models
{
    public class TFSWorkItem
    {
        public int WorkItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AssignedTo { get; set; }
        public string IterationPath { get; set; }
        public int Priority { get; set; }
        public string State { get; set; }

        /*CREATE TABLE TFSWorkItem (
            WorkItemID INT PRIMARY KEY,
            Title NVARCHAR(255) NOT NULL,
            Description NVARCHAR(MAX),
            CreatedBy NVARCHAR(100),
            CreatedDate DATETIME,
            AssignedTo NVARCHAR(100),
            IterationPath NVARCHAR(255),
            Priority INT,
            State NVARCHAR(50),
            -- Add additional fields as needed
        );*/
    }
}