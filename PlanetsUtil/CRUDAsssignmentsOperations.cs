using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace PlanetsUtil
{
    internal class CRUDAsssignmentsOperations
    {
        internal DBMappingContext context;

        internal CRUDAsssignmentsOperations(DBMappingContext context)
        {
            this.context = context;
            
        }
        internal bool Create(Assignment obj, out string errorMessage)
        {
            if (obj.planet <= 0)
            {
                errorMessage = "Planet Id is empty or negative.";
                return false;
            }
            if (obj.planetProperty <= 0)
            {
                errorMessage = "Planet Property Id is empty or negative.";
                return false;
            }

            if (context.AssignmentModel.Any(am => am.planet == obj.planet && am.planetProperty == obj.planetProperty))
            {
                errorMessage = "Assignment already exists in this system.";
                return false;
            }
            else
            {
                context.AssignmentModel.Add(obj);
                context.SaveChanges();
                errorMessage = null;
                return true;
            }
        }
        
        internal void Update(Assignment assign)
        {
            Assignment assignement  = context.AssignmentModel.Find(assign.assignmentId);
            assignement = assign;
            context.SaveChanges();
            
        }
        internal void Delete(Assignment assign)
        {
            context.AssignmentModel.Remove(assign);
            context.SaveChanges();
        }
        internal List<Assignment> ReadAll()
        {
            return context.AssignmentModel.ToList<Assignment>(); 
        }
        internal Assignment ReadById(int assignmentId)
        {
            Assignment asssignment = context.AssignmentModel.FirstOrDefault(x => x.assignmentId == assignmentId);
            return asssignment;
            
        }
        internal Assignment ReadByPlanetId(int planetId)
        {
            Assignment asssignment = context.AssignmentModel.FirstOrDefault(x => x.planet == planetId);
            return asssignment;
        }
        internal Assignment ReadByPropertyId(int propertyId)
        {
            Assignment asssignment = context.AssignmentModel.Single(x => x.planetProperty == propertyId);
            return asssignment;
        }

        internal bool Exists(Assignment assign)
        {
            return context.AssignmentModel.Any(e => e.assignmentId == assign.assignmentId);
        }
    }
}
