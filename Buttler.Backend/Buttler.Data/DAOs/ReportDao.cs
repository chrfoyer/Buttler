﻿using Buttler.Domain.Model;
using Buttler.Logic.DaoInterfaces;
using Buttler.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Buttler.Data.DAOs;

public class ReportDao : IReportDao
{

    private ApplicationDbContext context;

    public ReportDao(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Report> CreateReportAsync(ReportCreationDto dto)
    {
        Report newReport = new Report();
        newReport.TimeStamp = dto.TimeStamp;
        newReport.WasteType = dto.WasteType;
        newReport.NumberOfWaste = dto.NumberOfWaste;

        EntityEntry<Report> added = await context.Reports.AddAsync(newReport);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Report>> GetAllReportsAsync()
    {
        List<Report> reports = await context.Reports.ToListAsync();
        return reports;
    }
}