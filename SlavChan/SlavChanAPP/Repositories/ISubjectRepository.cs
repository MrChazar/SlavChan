﻿using SlavChanAPP.Models;
using System;

namespace SlavChanAPP.Repositories
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll(int boardId);

        Subject Get(int subjectId);

        void Save(Subject subject, string? Name, string? UserName); 

        void Delete();

        void UpdateAllTime();

        void UpdateTimeById(int subjectId);
    }
}
