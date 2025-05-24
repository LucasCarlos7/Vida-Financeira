using VF.Core.Models;
using VF.Core.ViewModels;

namespace VF.Core.Interfaces.Repositories;

public interface IMemberRepository
{
    Task RegisterAsync(MemberModel member);

    Task<List<MembersViewModel>> GetAllAsync();
}
