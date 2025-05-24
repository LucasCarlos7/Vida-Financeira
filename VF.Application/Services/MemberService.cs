using AutoMapper;
using VF.Core.InputModels;
using VF.Core.Interfaces.Repositories;
using VF.Core.Interfaces.Services;
using VF.Core.Models;
using VF.Core.ViewModels;

namespace VF.Application.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public MemberService
    (
        IMemberRepository memberRepository,
        IMapper mapper
    )
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task RegisterAsync(MemberInputModel inputModel)
    {
        if (inputModel is null)
            throw new ArgumentNullException(nameof(inputModel));

        var newMember = _mapper.Map<MemberModel>(inputModel);

        await _memberRepository.RegisterAsync(newMember);
    }

    public async Task<List<MembersViewModel>> GetAllAsync()
    {
        var members = await _memberRepository.GetAllAsync();

        return members;
    }

}
