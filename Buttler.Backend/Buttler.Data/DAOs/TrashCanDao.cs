using Buttler.Domain.Model;
using Buttler.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Buttler.Data.DAOs;

public class TrashCanDao
{
    private ApplicationDbContext context;

    public TrashCanDao(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Trashcan> CreateReportAsync(TrashCanCreationDto dto)
    {
        Trashcan newTrashCan = new Trashcan();
        newTrashCan.TimeStamp = DateTime.Now.ToUniversalTime();
        newTrashCan.TrashCanType = dto.TrashCanType;
        newTrashCan.NumberOfTrashCans = dto.NumberOfTrashCans;
        newTrashCan.UserName = dto.UserName;
        newTrashCan.Latitude = dto.Latitude;
        newTrashCan.Longitude = dto.Longitude;


        EntityEntry<Trashcan> added = await context.TrashCans.AddAsync(newTrashCan);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Trashcan>> GetAllReportsAsync()
    {
        List<Trashcan> Trashcans = await context.TrashCans.ToListAsync();
        return Trashcans;
    }
}