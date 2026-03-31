const App = () => {
  return (
      <div style={styles.container}>
        <div style={styles.header}>
          <h1 style={styles.title}> Finance</h1>
          <p style={styles.subtitle}> Budget overview and transaction tracking</p>
        </div>

        <div style={styles.statsRow}>
          <div style={styles.statCard}>
            <span style={styles.statLabel}>Monthly Budget</span>
            <span style={styles.startValue}>R 12,000</span>
          </div>
          <div style={styles.statCard}>
            <span style={styles.statLabel}>Spent</span>
            <span style={styles.statValue}>R 7,340</span>
          </div>
          <div style={styles.statCard}>
            <span style={styles.statLabel}>Remaining</span>
            <span style={styles.statValue}>R 5,160</span>
          </div>
        </div>

        <div style={styles.transaction}>
          <h2 style={styles.sectionTitle}> Recent Transactions</h2>
          {transactions.map((t) => (
              <div key={t.id} style={styles.transactionRow}>
                <span>{t.description}</span>
                <span style={{ color: t.amount <0? '#e74c3c' : '#2ecc71'}}>
                  R {Math.abs(t.amount).toFixed(2)}
                </span>
              </div>
          ))}
        </div>
      </div>
  )
}

const transactions = [
  { id:1, description: 'Checkers Groceries', amount: -1500},
  { id:2, description: 'Petrol', amount: -950},
  {id:3, description: 'Deposit', amount: 15500},
  {id:4, description: 'SteveMadden', amount: -1400},
]

const styles: Record<string, React.CSSProperties> = {
  container: {
    fontFamily: 'sans-serif',
    padding: '24px',
    background: '#f9fafb',
    minHeight: '100vh'
  },
  header: {
    marginBottom: '24px',
  },
  title: {
    margin: 0,
    fontSize: '28px',
    color: '#1a1a2e'
  },
  subtitle: {
    color: '#666',
    margin: '4px 0 0'
  },
  statsRow: {
    display: 'flex',
    gap: '16px',
    marginBottom: '32px'
  },
  statCard: {
    flex: 1,
    background: '#fff',
    borderRadius: '8px',
    padding: '16px',
    display: 'flex',
    flexDirection: 'column',
    gap: '8px',
    boxShadow: '0 1px 4px rgba(0,0,0,0.08)'
  },
  statLabel: {
    fontSize: '12px',
    color: '#888',
    textTransform: 'uppercase',
    letterSpacing: '0.05em'
  },
  statValue: {
    fontSize: '22px',
    fontWeight: 'bold',
    color: '#1a1a2e'
  },
  transactions: {
    background: '#fff',
    borderRadius: '8px',
    padding: '16px',
    boxShadow: '0 1px 4px rgba(0,0,0,0.08)'
  },
  sectionTitle: {
    fontSize: '16px',
    marginTop: 0,
    marginBottom: '16px',
    color: '#1a1a2e'
  },
  transactionRow: {
    display: 'flex',
    justifyContent: 'space-between',
    padding: '10px 0',
    borderBottom: '1px solid #f0f0f0',
    fontSize: '14px'
  }
}
export default App