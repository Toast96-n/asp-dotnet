namespace prac6.Models;

public class PayslipRecord
{
    public string Month { get; init; } = string.Empty;
    public decimal BasicSalary { get; init; }
    public decimal Allowances { get; init; }
    public decimal Tax { get; init; }
    public decimal Insurance { get; init; }
    public decimal LeaveDeduction { get; init; }
    public decimal GrossPay => BasicSalary + Allowances;
    public decimal TotalDeductions => Tax + Insurance + LeaveDeduction;
    public decimal NetPay => GrossPay - TotalDeductions;
}

public class PayrollDeduction
{
    public string Type { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal Amount { get; init; }
}

public static class PayrollStore
{
    public static decimal AnnualSalary { get; } = 72000m;

    public static IReadOnlyList<PayslipRecord> Payslips { get; } =
    [
        new PayslipRecord
        {
            Month = "October 2026",
            BasicSalary = 6000m,
            Allowances = 450m,
            Tax = 900m,
            Insurance = 180m,
            LeaveDeduction = 0m
        },
        new PayslipRecord
        {
            Month = "September 2026",
            BasicSalary = 6000m,
            Allowances = 450m,
            Tax = 900m,
            Insurance = 180m,
            LeaveDeduction = 125m
        }
    ];

    public static IReadOnlyList<PayrollDeduction> Deductions { get; } =
    [
        new PayrollDeduction { Type = "Income tax", Description = "October 2026 payroll withholding", Amount = 900m },
        new PayrollDeduction { Type = "Health insurance", Description = "Monthly employee premium", Amount = 180m },
        new PayrollDeduction { Type = "Leave adjustment", Description = "September 2026 unpaid leave adjustment", Amount = 125m }
    ];
}

public class PayrollDashboardViewModel
{
    public decimal AnnualSalary { get; init; }
    public PayslipRecord LatestPayslip { get; init; } = new();
    public IReadOnlyList<PayslipRecord> Payslips { get; init; } = [];
}
