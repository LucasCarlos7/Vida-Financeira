using VF.Core.InputModels;
using VF.Core.ViewModels;

namespace VF.Core.Interfaces.Services;

public interface IMemberService
{
    Task RegisterAsync(MemberInputModel inputModel);

    Task<List<MembersViewModel>> GetAllAsync();
}
