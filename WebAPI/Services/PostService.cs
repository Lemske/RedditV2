﻿using Application.LogicInterfaces;
using Domain.Models;
using Shared.DTOs;

namespace WebAPI.Services;

public class PostService : IPostService
{
    private IPostLogic _logic;

    public PostService(IPostLogic logic)
    {
        _logic = logic;
    }

    public Task<PostDTO> CreateAsync(PostCreationDTO dto)
    {
        if (string.IsNullOrEmpty(dto.OwnerUsername))
        {
            throw new Exception("Username cannot be empty.");
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new Exception("Title cannot be empty.");
        }
        if (string.IsNullOrEmpty(dto.Topic))
        {
            throw new Exception("Topic cannot be empty.");
        }

        return _logic.CreateAsync(dto);
    }

    public Task<IEnumerable<Post>> GetAsync(SeachPostParaneterDTO searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}