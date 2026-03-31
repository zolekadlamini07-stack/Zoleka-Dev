import React, { Suspense, useState } from 'react'

const FinanceApp = React.lazy(() => import('financeApp/App'))
const HrApp = React.lazy(() => import('hrApp/App'))

type AppKey = 'finance' | 'hr' | null

const tiles = [
  { key: 'finance' as AppKey, label: 'Finance', description: 'Budget and transactions' },
  { key: 'hr' as AppKey, label: 'HR ', description: 'Team and leave management' },
]

const App = () => {
  const [activeApp, setActiveApp] = useState<AppKey>(null)

  return (
      <div style={styles.container}>
        <header style={styles.header}>
          <h1 style={styles.logo}> Portal</h1>
          {activeApp && (
              <button style={styles.backButton} onClick={() => setActiveApp(null)}>
                ← Back to Dashboard
              </button>
          )}
        </header>

        {!activeApp ? (
            <div style={styles.dashboard}>
              <p style={styles.welcome}>Welcome back, Zoleka. Select an application to continue.</p>
              <div style={styles.tilesGrid}>
                {tiles.map((tile) => (
                    <div
                        key={tile.key}
                        style={styles.tile}
                        onClick={() => setActiveApp(tile.key)}
                    >
                      <span style={styles.tileIcon}>{tile.label.split(' ')[0]}</span>
                      <span style={styles.tileLabel}>{tile.label.split(' ')[1]}</span>
                      <span style={styles.tileDescription}>{tile.description}</span>
                    </div>
                ))}
              </div>
            </div>
        ) : (
            <Suspense fallback={<div style={styles.loading}>Loading application...</div>}>
              {activeApp === 'finance' && <FinanceApp />}
              {activeApp === 'hr' && <HrApp />}
            </Suspense>
        )}
      </div>
  )
}

const styles: Record<string, React.CSSProperties> = {
  container: {
    fontFamily: 'sans-serif',
    minHeight: '100vh',
    background: '#1a1a2e',
    color: '#ffffff'
  },
  header: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'space-between',
    padding: '20px 32px',
    borderBottom: '1px solid rgba(255,255,255,0.1)'
  },
  logo: {
    margin: 0,
    fontSize: '20px',
    letterSpacing: '0.05em'
  },
  backButton: {
    background: 'rgba(255,255,255,0.1)',
    border: '1px solid rgba(255,255,255,0.2)',
    color: '#fff',
    padding: '8px 16px',
    borderRadius: '6px',
    cursor: 'pointer',
    fontSize: '14px'
  },
  dashboard: {
    padding: '48px 32px'
  },
  welcome: {
    color: 'rgba(255,255,255,0.6)',
    marginBottom: '32px',
    fontSize: '15px'
  },
  tilesGrid: {
    display: 'grid',
    gridTemplateColumns: 'repeat(auto-fill, minmax(200px, 1fr))',
    gap: '16px',
    maxWidth: '600px'
  },
  tile: {
    background: 'rgba(255,255,255,0.06)',
    border: '1px solid rgba(255,255,255,0.1)',
    borderRadius: '12px',
    padding: '24px',
    cursor: 'pointer',
    display: 'flex',
    flexDirection: 'column',
    gap: '6px',
    transition: 'background 0.2s'
  },
  tileIcon: {
    fontSize: '28px'
  },
  tileLabel: {
    fontSize: '16px',
    fontWeight: '600'
  },
  tileDescription: {
    fontSize: '12px',
    color: 'rgba(255,255,255,0.5)'
  },
  loading: {
    padding: '48px 32px',
    color: 'rgba(255,255,255,0.5)'
  }
}

export default App