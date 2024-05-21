using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Frank.Service.Common
{
    public class Constant
    {
        /// <summary>
        /// kiểu hiển thị file
        /// </summary>
        public enum SHOW_FILE_TYPE
        {
            NONE,
            IMG,
            PDF,
            NO_SUPPORT
        }
        public enum WORKFLOW_SHOWTYPE
        {
            USER,
            ROLE
        }

        public enum EDIT_OBJECT_ENUM
        {
            FAIL,
            SUCCESS
        }

        public enum WORKFLOW_REQUEST_EDIT
        {
            NEW,
            PENDING,
            RESOLVED
        }

        public enum FILE_TYPE_ENUM
        {
            IMAGE,
            PDF,
            OTHER,
            WORD
        }
    }
}
