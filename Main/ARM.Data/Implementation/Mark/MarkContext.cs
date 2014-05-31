﻿using System.Data.Entity;
using ARM.Data.Interfaces.Mark;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Mark
{
    /// <summary>
    /// Контекст бази даних для оцінок
    /// </summary>
    public class MarkContext : BaseContext<Models.Mark>, IMarkContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="MarkContext"/> class.
        /// </summary>
        public MarkContext()
        {
            
        }
        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // marks
            modelBuilder.Entity<Models.Mark>()
                .HasRequired(c => c.Student)
                .WithMany(c => c.Marks)
                .HasForeignKey(c => c.StudentId)
                .WillCascadeOnDelete(false);
        }
    }
}