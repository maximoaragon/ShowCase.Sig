#region "Using"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
#endregion "Using"

namespace Exchange.Contracts
{
    /// <summary>
    /// Implements the ProcessWorkflowDto
    /// </summary>
    public class ProcessWorkflow
    {
        #region "Properties / Attributes"
        /// <summary>
        /// Gets/sets the ProcessWorkflowID property
        /// </summary>
        public int ProcessWorkflowID { get; set; }

        /// <summary>
        /// Gets/sets the ProcessWorkflowCategoryID property
        /// </summary>
        public int ProcessWorkflowCategoryID { get; set; }

        /// <summary>
        /// Gets/sets the WorkflowName property
        /// </summary>
        public string WorkflowName { get; set; }

        /// <summary>
        /// Gets/sets the WorkflowDescription property
        /// </summary>
        public string WorkflowDescription { get; set; }

        /// <summary>
        /// Gets/sets the ProgramControl property
        /// </summary>
        public int ProgramControl { get; set; }

        /// <summary>
        /// Gets/sets the DefinitionMarkup property
        /// </summary>
        public string DefinitionMarkup { get; set; }

        #endregion "Properties / Attributes"
    }
}
