using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
    public class DeleteFolderResponseModel : BaseResponseModel
    {
        public DeletedFolder deletedFolder { get; set; }

        public class DeletedFolder
        {

            public string name { get; set; }
            public string status { get; set; }
        }


    }
}