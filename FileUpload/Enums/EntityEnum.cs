using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Enums
{
    public enum EntityEnum
    {

    }

    public enum TransactionCSVStatus
    {
        Approved = 1,
        Failed = 2,
        Finished = 3
    }

    public enum ConfigUploadFileTypeId
    {
        CSV = 1,
        XML = 2
    }
}
