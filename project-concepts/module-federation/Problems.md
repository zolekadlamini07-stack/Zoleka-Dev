# Module Federation
Issues I encountered during development of this demo and how they were resolved.

---
## 1. Wrong remote URL fails silently

If a remote URL in the host vite config points to the wrong port, the host loads the wrong application with no error or warning.

Federation resolves at runtime in the browser. TypeScript does not catch this at build time. The build succeeds and the error only appears when the browser attempts to load the remote.

Fix: Verify that each remote URL in the host config matches the correct port. In production use environment variables to avoid hardcoded URLs.

---

## 2. Stale cache after rebuilding a remote

Changes made to a remote do not reflect in the host until the remote is rebuilt and re-served. The browser caches chunk files by filename. If Vite generates the same filenames after a rebuild, the browser serves the cached version.

Fix: After changing a remote — rebuild it, re-serve it, then hard refresh the browser with Ctrl + Shift + R.

In production this is handled by content hashing in filenames. When content changes the filename changes, the browser has never seen it before and fetches it fresh.

---
