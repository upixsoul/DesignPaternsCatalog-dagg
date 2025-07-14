using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Interpreter
{
    // Context class representing the user
    public class UserContext
    {
        public string Role { get; set; }
        public string Department { get; set; }
    }

    // Interface for expressions
    public interface IExpression
    {
        bool Interpret(UserContext context);
    }

    // Terminal expression: Check user role
    public class RoleExpression : IExpression
    {
        private readonly string _role;
        public RoleExpression(string role) => _role = role;
        public bool Interpret(UserContext context) => context.Role.Equals(_role, StringComparison.OrdinalIgnoreCase);
    }

    // Terminal expression: Check user department
    public class DepartmentExpression : IExpression
    {
        private readonly string _department;
        public DepartmentExpression(string department) => _department = department;
        public bool Interpret(UserContext context) => context.Department.Equals(_department, StringComparison.OrdinalIgnoreCase);
    }

    // Non-terminal expression: OR operation
    public class OrExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;
        public OrExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }
        public bool Interpret(UserContext context) => _left.Interpret(context) || _right.Interpret(context);
    }

    // Non-terminal expression: AND operation
    public class AndExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;
        public AndExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }
        public bool Interpret(UserContext context) => _left.Interpret(context) && _right.Interpret(context);
    }

    // Usage in a .NET backend service
    public class AccessControlService
    {
        public bool HasAccess(UserContext user, IExpression rule)
        {
            return rule.Interpret(user);
        }
    }
}
