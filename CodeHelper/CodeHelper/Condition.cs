using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public class Condition
    {
        //选中的表格
        public string CDataTable;

        //使用的DLL类
        public DLLName DLLName;

        //结果类型,比如存储过程,
        public ResultType ResultType;

        #region Entity中使用的参数
        //Entity的类型，比如Entity,InputDto,OutputDto
        public EntityType EntityType;

        //Entity类的访问级别，比如public，protect
        public string EntityAccessType;
        #endregion

        #region Proc中使用的参数(OperationType在DAL中也使用了)
        //操作类型,比如Add，Get等
        public OperationType OperationType;

        //是否返回ID
        public bool IsProcReturnID;
        #endregion

        #region DAL中使用的参数OperationType定义在Proc里了)
        //操作类型OperationType

        //Dal类的返回值类型,int,string等
        public string DALReturnType;

        //DAL中的CommandType
        public DALCommandType CommandType;

        //DAL中Add是否回传ID
        public bool IsDALReturnID;

        //Dal类的访问级别，比如public，protect
        public string DALAccessType;
        #endregion

        #region 最终代码中需要用到的其他参数
        //当前表的所有参数
        public List<OriginalParameter> ALLParameters;

        //选中的参数
        public List<string> ChoosenParameters;

        //最终的参数
        public List<FinalParameter> FinalParameters;

        ////传入的参数
        //public List<string> OriginalParameters;

        ////传入参数的许多最终属性，比如名称，类型，长度等
        //public List<string[]> FinalParameters;

        ////传入的参数的部分属性（格式：名称\t类型）
        //public List<string> AllParameterNames;
        #endregion
        ////DAL中Add是否回传ID
        //public bool BReturnID;

        ////Add的存储过程中，是否回传ID
        //public bool BPReturnID;

        ////存储过程的类型，比如Add，Get等
        //public string CBPType;

        ////Dal类的返回值类型,int,string等
        //public string CBDaBReturnType;

        ////Sql的大类型，是查询还是操作数据
        //public string CBDaBSql;

        ////DAL中的具体操作，Add，Get等
        //public string CBDaBOperation;

        ////DAL中的CommandType
        //public string CBDaBCommandType;

        ////Dal类的访问级别，比如public，protect
        //public string CDALType;

        ////Audited传入的参数
        //public List<string> AuditedParameters;

        ////传入参数的许多最终属性，比如名称，类型，长度等
        //public List<string[]> FAuditedParameters;

        ////传入的参数的部分属性（格式：名称\t类型）
        //public List<string> AllAuditedParameterNames;

        ////传入的参数
        //public List<string> CParameters;

        ////传入参数的许多最终属性，比如名称，类型，长度等
        //public List<string[]> FParameters;

        ////传入的参数的部分属性（格式：名称\t类型）
        //public List<string> CAllParameterNames;

        ////是否用户注册
        //public string IsRegisterd;

        ////是否含Created
        //public string IsCreated;

        ////是否含Updated
        //public string IsUpdated;

        ////是否含Audited
        //public string IsAudited;

        ////是否含Deleted
        //public string IsDeleted;

        ////Created传入的参数
        //public List<string> CreatedParameters;

        ////传入参数的许多最终属性，比如名称，类型，长度等
        //public List<string[]> FCreatedParameters;

        ////传入的参数的部分属性（格式：名称\t类型）
        //public List<string> AllCreatedParameterNames;

        ////Updated传入的参数
        //public List<string> UpdatedParameters;

        ////传入参数的许多最终属性，比如名称，类型，长度等
        //public List<string[]> FUpdatedParameters;

        ////传入的参数的部分属性（格式：名称\t类型）
        //public List<string> AllUpdatedParameterNames;

        ////Audited传入的参数
        //public List<string> AuditedParameters;

        ////传入参数的许多最终属性，比如名称，类型，长度等
        //public List<string[]> FAuditedParameters;

        ////传入的参数的部分属性（格式：名称\t类型）
        //public List<string> AllAuditedParameterNames;

        ////Deleted传入的参数
        //public List<string> DeletedParameters;

        ////传入参数的许多最终属性，比如名称，类型，长度等
        //public List<string[]> FDeletedParameters;

        ////传入的参数的部分属性（格式：名称\t类型）
        //public List<string> AllDeletedParameterNames;

        //public Operation Create = new Operation();

        //public Operation Update = new Operation();

        //public Operation Delete = new Operation();

        //public Operation Audit = new Operation();

        //public Operation All = new Operation();

        public KeyInfo KeyInfo = new KeyInfo();

        //public Parameter RegisterInfo = new Parameter();

        public string RegisterName;



        ////
        //public string CBDaBType;



        ////
        //public string CReturnType;





    }
}
