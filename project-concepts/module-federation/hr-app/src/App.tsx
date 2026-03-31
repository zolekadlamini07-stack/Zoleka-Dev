const App = () => {
  return (
      <div style={styles.container}>
        <div style={styles.header}>
          <h1 style={styles.title}> HR</h1>
          <p style={styles.subtitle}>Team management and leave tracking</p>
        </div>

        <div style={styles.teamList}>
          <h2 style={styles.sectionTitle}>Team Members</h2>
          {team.map((member) => (
              <div key={member.id} style={styles.memberRow}>
                <div style={styles.avatar}>{member.initials}</div>
                <div>
                  <div style={styles.memberName}>{member.name}</div>
                  <div style={styles.memberRole}>{member.role}</div>
                </div>
                <span style={{
                  ...styles.badge,
                  background: member.status === 'Active' ? '#e8f5e9' : '#fff3e0',
                  color: member.status === 'Active' ? '#2e7d32' : '#e65100'
                }}>
              {member.status}
            </span>
              </div>
          ))}
        </div>
      </div>
  )
}

const team = [
  { id: 1, name: 'Zoleka Dlamini', initials: 'ZD', role: ' Developer', status: 'Active' },
  { id: 2, name: 'Zoey Langa', initials: 'ZL', role: 'Developer', status: 'Active' },
  { id: 3, name: 'Jane Van', initials: 'JV', role: 'HR', status: 'Active' },
]

const styles: Record<string, React.CSSProperties> = {
  container: {
    fontFamily: 'sans-serif',
    padding: '24px',
    background: '#f9fafb',
    minHeight: '100vh'
  },
  header: {
    marginBottom: '24px'
  },
  title: {
    fontSize: '28px',
    margin: 0,
    color: '#1a1a2e'
  },
  subtitle: {
    color: '#666',
    margin: '4px 0 0'
  },
  teamList: {
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
  memberRow: {
    display: 'flex',
    alignItems: 'center',
    gap: '12px',
    padding: '10px 0',
    borderBottom: '1px solid #f0f0f0'
  },
  avatar: {
    width: '36px',
    height: '36px',
    borderRadius: '50%',
    background: '#1a1a2e',
    color: '#fff',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    fontSize: '12px',
    fontWeight: 'bold',
    flexShrink: 0
  },
  memberName: {
    fontSize: '14px',
    fontWeight: '500',
    color: '#1a1a2e'
  },
  memberRole: {
    fontSize: '12px',
    color: '#888'
  },
  badge: {
    marginLeft: 'auto',
    fontSize: '11px',
    padding: '3px 8px',
    borderRadius: '12px',
    fontWeight: '500'
  }
}

export default App