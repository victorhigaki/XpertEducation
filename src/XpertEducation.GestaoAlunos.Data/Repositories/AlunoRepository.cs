﻿using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain.Models;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Data.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly GestaoAlunosContext _context;

    public AlunoRepository(GestaoAlunosContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Aluno?> ObterPorId(Guid id)
    {
        return await _context.Alunos.FindAsync(id);
    }

    public async Task Adicionar(Aluno aluno)
    {
        await _context.Alunos.AddAsync(aluno);
    }

    public async Task<Matricula?> ObterMatriculaPorAlunoId(Guid AlunoId)
    {
        var matricula = await _context.Matriculas.FirstOrDefaultAsync(m => m.AlunoId == AlunoId);
        return matricula;
    }

    public void AdicionarMatricula(Matricula matricula)
    {
        _context.Matriculas.Add(matricula);
    }

    public void AtualizarMatricula(Matricula matricula)
    {
        _context.Matriculas.Update(matricula);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

