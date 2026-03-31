# Module Federation

## The Concept

Module Federation is a Vite/Webpack feature that allows multiple independently deployed frontend applications to share code and components at runtime rather than at build time.

In a standard React app, all code is bundled together at build time. With module federation, a host application can load remote applications dynamically in the browser — without them being part of its build.

## Key Terms

| Term | Meaning |
|---|---|
| Host / Shell | The container application that loads remotes |
| Remote | An independently deployed app that exposes components |
| remoteEntry.js | The manifest file a remote generates — tells the host what is available |
| Shared | Dependencies declared as shared are loaded once and reused across host and remotes |

## What the Demo Covers

- Configuring a host and two remotes using @originjs/vite-plugin-federation
- Runtime loading via React.lazy and Suspense
- Shared dependencies (react, react-dom) to prevent duplicate loading
- Role-based tile rendering — users only see apps assigned to them
- Auth context passed from shell to remotes via props

## Project Structure

```
module-federation/
├── portal/         host application — login, dashboard, tile navigation
├── finance-app/    remote 1 — budget overview and transactions
└── hr-app/         remote 2 — team management
```

## Setup and Running

Remotes must be built and served before the portal starts.
The portal fetches remoteEntry.js at runtime — if remotes are not running there is nothing to fetch.

Terminal 1 — finance-app:
```
cd finance-app
npm install
npm run build
npm run preview
```
Runs on http://localhost:5001

Terminal 2 — hr-app:
```
cd hr-app
npm install
npm run build
npm run preview
```
Runs on http://localhost:5002

Terminal 3 — portal:
```
cd portal
npm install
npm run dev
```
Runs on http://localhost:5000

## Key Gotchas

See GOTCHAS.md for issues encountered during development and how they were resolved.
