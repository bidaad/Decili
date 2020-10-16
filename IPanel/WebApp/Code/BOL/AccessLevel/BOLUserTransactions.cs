using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using Decili.Code.DAL;

public class BOLUserTransactions : BaseBOLUserTransactions, IBaseBOL<UserTransactions>
{

    public BOLUserTransactions(params int[] MCodes) : base(MCodes)
    {

    }
    public IList CheckBusinessRules()
    {
        var messages = new List<string>();

        #region Business Rules
        //Example
        //if (string.IsNullOrEmpty(this.FirstName))
        //    messages.Add("Please fill FirstName.");

        #endregion
        return messages;
    }



    internal int Insert(int? UserCode, DateTime? ChargeDate, int HCTransStatusCode, int? HCPayMethodCode, string UserIP, int Amount, int HCPayReasonCode, int? DecilCount, int? AdsCode, int BankCode)
    {
        //try
        //{

            UserTransactions NewRecord = new UserTransactions();
            dataContext.UserTransactions.InsertOnSubmit(NewRecord);
            if (UserCode != null)
                NewRecord.UserCode = (int)UserCode;
            if (ChargeDate != null)
                NewRecord.ChargeDate = (DateTime)ChargeDate;
            NewRecord.HCTransStatusCode = HCTransStatusCode;
            NewRecord.UserIP = UserIP;
            NewRecord.Amount = Amount;
            NewRecord.PayDate = ChargeDate;
            if (HCPayMethodCode != null)
                NewRecord.HCPayMethodCode = (int)HCPayMethodCode;
            NewRecord.HCPayReasonCode = (int)HCPayReasonCode;
            NewRecord.DecilCount = DecilCount;
            NewRecord.ItemCode = AdsCode;
            NewRecord.BankCode = BankCode;
            dataContext.SubmitChanges();

            return NewRecord.Code;
        /*}
        catch(Exception err)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert("Insert Order", DateTime.Now, "", err.Message);
            return 0;
        }*/
    }

    internal int Insert(int? UserCode, DateTime? ChargeDate, DateTime? PayDate, int HCTransStatusCode, int Amount,
        string BankName, string BankState, string Comment, string FishNo, int? JournalCode, int? HCPayReasonCode, int HCPayMethodCode, int? RelatedTransCode, int? HCFishTypeCode)
    {
        try
        {

            UserTransactions NewRecord = new UserTransactions();
            dataContext.UserTransactions.InsertOnSubmit(NewRecord);
            if (ChargeDate != null)
                NewRecord.ChargeDate = (DateTime)ChargeDate;
            if (PayDate != null)
                NewRecord.PayDate = (DateTime)PayDate;
            if (UserCode != null)
                NewRecord.UserCode = (int)UserCode;
            if (HCPayReasonCode != null)
                NewRecord.HCPayReasonCode = HCPayReasonCode;

            NewRecord.HCTransStatusCode = HCTransStatusCode;
            NewRecord.Amount = Amount;
            NewRecord.HCTransStatusCode = HCTransStatusCode;
            NewRecord.HCPayMethodCode = HCPayMethodCode;
            NewRecord.BankName = BankName;
            NewRecord.BankState = BankState;
            NewRecord.Comment = Comment;
            NewRecord.FishNo = FishNo;
            dataContext.SubmitChanges();

            return NewRecord.Code;
        }
        catch
        {
            return 0;
        }
    }

    internal int Insert(int? UserCode, DateTime? ChargeDate, int HCTransStatusCode, int? HCPayMethodCode, string UserIP, int Amount, int HCPayReasonCode, int? DecilCount, int? AdsCode, int BankCode, int HCMembershipTypeCode, int MemLen)
    {
        //try
        //{

        UserTransactions NewRecord = new UserTransactions();
        dataContext.UserTransactions.InsertOnSubmit(NewRecord);
        if (UserCode != null)
            NewRecord.UserCode = (int)UserCode;
        if (ChargeDate != null)
            NewRecord.ChargeDate = (DateTime)ChargeDate;
        NewRecord.HCTransStatusCode = HCTransStatusCode;
        NewRecord.UserIP = UserIP;
        NewRecord.Amount = Amount;
        NewRecord.PayDate = ChargeDate;
        if (HCPayMethodCode != null)
            NewRecord.HCPayMethodCode = (int)HCPayMethodCode;
        NewRecord.HCPayReasonCode = (int)HCPayReasonCode;
        NewRecord.DecilCount = DecilCount;
        NewRecord.ItemCode = AdsCode;
        NewRecord.BankCode = BankCode;
        NewRecord.MemTypeCode = HCMembershipTypeCode;
        NewRecord.MemLen = MemLen;
        dataContext.SubmitChanges();

        return NewRecord.Code;
        /*}
        catch(Exception err)
        {
            BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
            ErrorLogsBOL.Insert("Insert Order", DateTime.Now, "", err.Message);
            return 0;
        }*/
    }

    internal bool UpdateRequestKey(int UserTransactionCode, string requestKey)
    {
        try
        {
            UserTransactions CurRecord = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(UserTransactionCode));
            if (CurRecord != null)
            {
                CurRecord.BMIRequestKey = requestKey;
                dataContext.SubmitChanges();
                return true;
            }
            else
                return false;
        }
        catch
        {
            return false;
        }
    }

    internal UserTransactions GetTransactionByOrderID(long OrderId, int UserCode)
    {
        return dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(OrderId) && p.UserCode.Equals(UserCode));
    }


    internal bool Update(int Code, DateTime? ChargeDate, DateTime? PayDate, int HCTransStatusCode, int Amount, string BankName, string BankState, string Comment, string FishNo)
    {
        try
        {
            UserTransactions NewRecord = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(Code));
            if (ChargeDate != null)
                NewRecord.ChargeDate = (DateTime)ChargeDate;
            if (PayDate != null)
                NewRecord.PayDate = (DateTime)PayDate;
            NewRecord.HCTransStatusCode = HCTransStatusCode;
            NewRecord.Amount = Amount;
            NewRecord.HCTransStatusCode = HCTransStatusCode;
            NewRecord.BankName = BankName;
            NewRecord.BankState = BankState;
            NewRecord.Comment = Comment;
            NewRecord.FishNo = FishNo;
            dataContext.SubmitChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    internal bool UpdateStatus(int OrderCode, int HCTransStatusCode)
    {
        try
        {
            UserTransactions CurTrans = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(OrderCode));
            if (CurTrans != null)
            {
                CurTrans.HCTransStatusCode = HCTransStatusCode;
                dataContext.SubmitChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal UserTransactions GetTransactionByTransactionCode(int TransactionCode)
    {
        return dataContext.UserTransactions.SingleOrDefault(p => p.HCTransStatusCode.Equals(TransactionCode));
    }

    internal IQueryable<UserTransactions> GetListByStatusCode(int HCTransStatusCode)
    {
        return dataContext.UserTransactions.Where(p => p.HCTransStatusCode.Equals(HCTransStatusCode));
    }

    internal object GetUserTrans(int UserCode)
    {
        return dataContext.vUserTransactions.Where(p => p.UserCode.Equals(UserCode) ).OrderByDescending(p => p.Code);
    }

    internal bool UpdateFishno(int Code, string FishNo)
    {
        try
        {
            UserTransactions CurTrans = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(Code));
            if (CurTrans != null)
            {
                CurTrans.FishNo = FishNo;
                dataContext.SubmitChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal bool FishExists(string FishNo, int UserCode)
    {
        return dataContext.UserTransactions.Where(p => p.FishNo.Equals(FishNo) && p.HCTransStatusCode.Equals(2)).Count() > 0;
    }

    internal UserTransactions GetDataByCode(int Code)
    {
        return dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(Code));
    }

    internal void Update2(int Code, string BankName, string BankState, string FishNo, DateTime? PayDate, string Comment)
    {
        try
        {
            UserTransactions CurTrans = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(Code));
            CurTrans.BankName = BankName;
            CurTrans.BankState = BankState;
            CurTrans.FishNo = FishNo;
            CurTrans.PayDate = PayDate;
            CurTrans.Description = Comment;

            dataContext.SubmitChanges();
        }
        catch
        {
        }
    }

    internal void UpdateFish(int Code, string BankName, string BankState, string FishNo, DateTime? PayDate, string Comment, int Amount, int HCPayMethodCode)
    {
        try
        {
            UserTransactions CurTrans = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(Code));
            CurTrans.BankName = BankName;
            CurTrans.BankState = BankState;
            CurTrans.FishNo = FishNo;
            CurTrans.PayDate = PayDate;
            CurTrans.Description = Comment;
            CurTrans.Amount = Amount;
            CurTrans.HCPayMethodCode = HCPayMethodCode;

            dataContext.SubmitChanges();
        }
        catch
        {
        }
    }





    internal void DeleteRecord(int TrasactionCode)
    {
        UserTransactions CurRecord = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(TrasactionCode));
        dataContext.UserTransactions.DeleteOnSubmit(CurRecord);
        dataContext.SubmitChanges();

    }


    internal UserTransactions GetTransactionByOrderID(long OrderId)
    {
        return dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(OrderId));
    }

    internal UserTransactions GetTransactionByCode(long OrderId)
    {
        return dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(OrderId));
    }

    internal bool UpdateAuthority(int UserTransactionCode, string Authority)
    {
        try
        {
            UserTransactions CurTrans = dataContext.UserTransactions.SingleOrDefault(p => p.Code.Equals(UserTransactionCode));
            if (CurTrans != null)
            {
                CurTrans.Authority = Authority;
                dataContext.SubmitChanges();
                return true;
            }
            else
                return false;
        }
        catch
        {
            return false;
        }
    }

    internal vUserTransactions GetTransByAuthority(string strAuthority)
    {
        return dataContext.vUserTransactions.SingleOrDefault(p => p.Authority.Equals(strAuthority));
    }

    internal object GetAll(int PageNo, int PageSize)
    {
        int skipCount = (PageNo - 1) * PageSize;
        return dataContext.vUserTransactions.OrderByDescending(p=> p.Code).Skip(skipCount).Take(PageSize);
    }

    internal int GetAllCount()
    {
        return dataContext.UserTransactions.Count();
    }
}
