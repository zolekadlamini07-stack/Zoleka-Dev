# Module Federation
30 March 2026
## The Concept

This demo introduces a mini demo I built to explore my understanding of Module Federation a pattern that was introduced to us for our next set of projects at DeHeus.
I have built a small frontend setup to demonstrate a host application that calls 2 remotes finance-app and the hr app

## Key Terms

| Term | Meaning |
|---|---|
| Host / Shell | The container application that loads remotes |
| Remote | An independently deployed app that exposes components |
| remoteEntry.js | The manifest file a remote generates — tells the host what is available |
| Shared | Dependencies declared as shared are loaded once and reused across host and remotes |

## To Run the Demo

the 2 Remotes must be built and served before the portal starts.The portal fetches remoteEntry.js at runtime

Terminal 1 - finance-app:
```
cd finance-app
npm install
npm run build
npm run preview
```
Runs on http://localhost:5001

Terminal 2 hr-app:
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

this demo include a changelog to document all notable topics covered under the module federaation. Please use the changelog to keep track of any updates made 
