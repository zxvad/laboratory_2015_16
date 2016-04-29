function SyncAPI() {
    this.syncDrivers = function () {};
    this.syncCars = function () {};
    this.syncIE = function () {};
    this.dispEvents = function () {};
    this.syncMileageCar = function () {};
}

function Authorize() {
    var user = {};

    var api_register = function (username, password) {
        return { user_data: ''};
    };

    var api_authorize = function (username, password) {
        return {result: '', user_data: ''};
    };

    this.register = function (username, password) { user = api_register(username,password).user_data; };
    this.authorize = function (username, password) {
        var response = api_authorize(username,password);
        user = response.user_data;
        return response.result;
    };
}

function SubIndEn() {
    var waybillList = [];
    var FinRecords = [];
    var driverList = [];
    var lastNotify = {};

    this.getWaybill = function (waybill_Id) { };
    this.createWaybill = function (driver_id, waybillData) { };
    this.updateWaybill = function (waybill_Id, waybillData) { };
    this.deleteWaybill = function (waybill_Id) { };

    this.getFinRecord = function (finRecord_Id) { };
    this.createFinRecord = function (finRecordData) { };
    this.updateFinRecord = function (finRecord_Id, finRecordData) { };
    this.deleteFinRecord = function (finRecord_Id) { };

    this.getDriverList = function () {};
    this.banDriver= function (driver_id) {};

    this.generateNotifi = function () {};
    this.configNotifi = function (notify_data) {};
}

function Dispathing() {
    var driverList = [];
    var carList = [];
    var iEList = [];

    this.getDriverList = function () {};
    this.getCarList = function () {};
    this.getIEList = function () {};
    this.bindDriver = function (driver_id, iE_id) {};
    this.bindCar = function (car_id, iE_id) {};
}

function IndividualEn() {
    var workShiftList = [];
    var workHistory = [];
    var statisticData = [];

    this.getLastWorkShift = function () {};
    this.getHistory = function () {};
    this.getStatisticData = function() { statisticData = new IStatistic(); };

    function IStatistic() {
        var finReport = function(eFilters, data){
            var filters = eFilters.join(',');
            return function calc(data, eFilters) {
            }
        };
        var denyList = [];
        var carList = [];

        this.getFinReport = function () {};
        this.getDenyList = function () {};
        this.getCarMileage = function () {};
        this.getCarEffect = function () {};
        this.getTimeLine = function () {};
    }
}

