/*
 * Demonstrates: Interfaces - Single Interface Implementation
 * Concept: LoanAgreement implements only IAuditable as it tracks changes but is not directly transactable
 */

namespace FinanceDomain.Interfaces;

public class LoanAgreement : IAuditable
{
    private readonly List<AuditEntry> _auditLog = [];

    public string AgreementNumber { get; }
    public string BorrowerName { get; }
    public decimal PrincipalAmount { get; }
    public decimal InterestRate { get; }
    public LoanStatus Status { get; private set; }

    public LoanAgreement(string agreementNumber, string borrowerName, decimal principalAmount, decimal interestRate)
    {
        AgreementNumber = agreementNumber;
        BorrowerName = borrowerName;
        PrincipalAmount = principalAmount;
        InterestRate = interestRate;
        Status = LoanStatus.Pending;
        RecordAudit("LOAN_CREATED", $"Principal: R{principalAmount:F2} | Rate: {interestRate:P2}");
    }

    public void Approve()
    {
        if (Status != LoanStatus.Pending)
            throw new InvalidOperationException("Only pending loans can be approved.");

        Status = LoanStatus.Approved;
        RecordAudit("LOAN_APPROVED", $"Agreement {AgreementNumber} approved");
    }

    public void Disburse()
    {
        if (Status != LoanStatus.Approved)
            throw new InvalidOperationException("Only approved loans can be disbursed.");

        Status = LoanStatus.Active;
        RecordAudit("LOAN_DISBURSED", $"Principal R{PrincipalAmount:F2} disbursed to {BorrowerName}");
    }

    public void Close()
    {
        if (Status != LoanStatus.Active)
            throw new InvalidOperationException("Only active loans can be closed.");

        Status = LoanStatus.Closed;
        RecordAudit("LOAN_CLOSED", $"Agreement {AgreementNumber} closed");
    }

    public IReadOnlyList<AuditEntry> GetAuditLog() => _auditLog.AsReadOnly();

    public void RecordAudit(string action, string details)
    {
        _auditLog.Add(new AuditEntry(action, details));
    }
}

public enum LoanStatus
{
    Pending,
    Approved,
    Active,
    Closed
}
