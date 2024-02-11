﻿namespace DalApi;

internal interface ISchedule
{
    DateTime? GetStartDate();

    DateTime? GetEndDate();

    void SetStartDate(DateTime? startDate);

    void SetEndDate(DateTime? endDate);

}