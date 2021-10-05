namespace CommonEntity
{
    public enum EnPageType
    { 
        Parent,
        Child
    }
    public enum enPages
    {
        Category,
        Note,
        User,
        UserRole
    }
    public enum enwebpages
    {

        UserEntry,
        Branchmaster,
        CategoryMaster,
    }

    public enum enMessageBoxType
    {
        Success = 1,
        Faliure = 2,
        Warrning = 3,
    }
    public enum enRequestModelOrPage
    {
        OnPage
     , OnModel
    }
    public enum enReceiveType
    {
        GRN,
        PRN,
        QCN
    }

    public enum enTransactionType : int
    {

        All = -1,
        PURCHASE = 1,
        PURCHASERETURN = 2,
        INWAREDFROMBRANCH = 3,
        OUTWARDTOBRANCH = 4,
        SALES = 5,
        SALESRETURN = 6,
        ISSUREGISTER = 7,
        PURCHASEORDER = 8,
        DIRECTPURCHASE = 9,
        QUOTATION = 10,
        STOCKTRANSFER = 11,
        INWARDFROMHO = 12,
        WAREHOUSEREQUEST,
        REGULARORDER,
        SPECIALORDER,
        PENDINGGRN,
        CREATEGRN
    }

    public enum enDataType
    {
        INT,
        DECIMAL,
        SINGLE,
        BOOL,
        DATETIME
    }
    public enum enAction
    {
        ALL,
        ADD,
        AREA,
        AUTHENTICATE,
        AUTOSUGESS,
        CITY,
        COUNTRY,
        DELETE,
        DISTINCT,
        EDIT,
        FillCombo,
        NONE,
        REGISTER,
        REQUESTFROMITEMATTR,
        REUESTFROMIREQUESETFROMITEM,
        SAVE,
        SELECTALL,
        SELECTONE,
        STATE,
        UPDATE,

    }
    public enum enRoleType
    {
        Add,
        Edit,
        Delete,
        View,
        ViewLog,
        Print

    }

    public enum enUserRoles : int
    {
            None = 0,
            CategoryMaster = 1,
            UserPermission = 2,
            UserMaster = 3,
            TemplateMaster = 4,
            RefTable = 5,
            EmployeeMaster = 6,
            CityState = 7,
            DriverMaster = 8,
            Customer = 9,
            CustomerAddress = 10,
            Shipments = 11,
            CashierProcess = 12,
            DayBegin = 13,
            DayClose = 14,
            PrepareShipment = 15,
            LocalShipment = 16,
            AirwayPackage = 17,
            AirwayInvoiceDetail = 18,
            AssignVendor = 19,
            AssignDriver = 20,
            FinanceMaster = 21,
            CourierBulkImport=22

    }



    public enum enCachKey
    {
        CompanyProfile,
        Role,
        Manufacturer,
        Category,
        World,
        ConfigurationKey,
        DefaultFieldsShow,
        TabPermission,
        CacheRoleTabKey,
        DefaultApprover,
        ParentLinkKey,
        GRNParentKey,

    }

    public enum enAddressType
    {
        Supplier,
        Customer,
        Company,
        Employee
    }


    public enum enGlobal
    {
        PK
    }
    public enum enCategory : int
    {
        Department,
        DocumentType,
        Location,
        Nationality,
        Position,
        UserRole,
        Packaging,
        PackingType,
        UOM,
        ServiceType,
        Vehicle,


    }



    public enum enComboOther
    {
        CountryName,
        CustomerAddress,
        StateName,
        CityName,
        StateNameByCountry,
        CityNameByState,
        DriverName,
        VendorName,

        UserFullName,
        ChangeHistory,

        SystemModules,
        ModuleName,
        UserName,

    }
    public enum ImportType
    {
        ALL
        , BRANCH
        , USERS
        , CATEGORY
        , CITY
        , COUNTRY
        , SUBCATEGORY
        , SERVICES
        , PROPERTY
        , CLUSTER
        , SPACE
        , INSTALLMENT
        , ITEM
        , COURSE
        , DISCOUNT
        , TRAINER

        , STATE
    }
    public enum enFollowUpType
    {
        QuotationFollowUp
        , GENERAL
        , PaymentFollowUp


    }
    public enum enWorldType
    {
        Country,
        State,
        City,
        Area
    }

    public enum enReportName
    {
        Enrollment,
        Invoice
    }
    public enum EnFilterType
    { 
        DataSet,
        List
    }
}



