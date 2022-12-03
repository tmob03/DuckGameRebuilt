﻿using Steamworks;

public class WorkshopQueryUser : WorkshopQueryUGC {

    internal AccountID_t _accountID;

    internal EUserUGCList _listType;

    internal EUGCMatchingUGCType _type;

    internal EUserUGCListSortOrder _sortOrder;

    public string cloudNameFileFilter { get; set; }

    internal WorkshopQueryUser(uint unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder) {
        _accountID = new AccountID_t(unAccountID);
        _listType = eListType;
        _type = eMatchingUGCType;
        _sortOrder = eSortOrder;
    }

    internal unsafe override void Create() 
    {
        _handle = SteamUGC.CreateQueryUserUGCRequest(_accountID, _listType, _type, _sortOrder, (AppId_t)312530, (AppId_t)312530, _page);
    }

    internal unsafe override void SetQueryData() {
        base.SetQueryData();

        SteamUGC.SetCloudFileNameFilter(_handle, cloudNameFileFilter);
    }

}
