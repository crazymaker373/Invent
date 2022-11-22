﻿using System.Text;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Model.Entities;

namespace Domain.Services;

public class HashGeneratorService : IHashGeneratorService{
    private IServiceScopeFactory _factory;

    public HashGeneratorService(IServiceScopeFactory factory){
        this._factory = factory;
    }

    public async Task<string> GenerateHashAsync(string LocationName = "NUL", int length = 6){
        var hash = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVW1234567890ß";
        var r = new Random();
        StringBuilder sb = new StringBuilder();
        sb.Append(LocationName);
        for (int i = 0; i < length; i++){
            sb.Append(hash[r.Next(0, hash.Length)]);
        }

        var fac = _factory.CreateScope().ServiceProvider.GetService<IRepository<Item>>();
        var list = await fac.ReadAllAsync();
        if (list.Any(e => e.Code == sb.ToString())){
            return await GenerateHashAsync(LocationName, length);
        }

        return sb.ToString();
    }
}