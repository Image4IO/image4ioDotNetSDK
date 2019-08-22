using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
 public   class CreateFolderResponseModel : BaseResponseModel
    {

        public CreatedFolder createdFolder { get; set; }

        public class CreatedFolder
        {
            public string name { get; set; }
            public string status { get; set; }
        }

    }
}
