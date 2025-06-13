import type React from "react"
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom"
import { useIsAuthenticated } from "@azure/msal-react"
import { AuthProvider } from "./context/AuthContext"

const AuthenticatedRoute: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const isAuthenticated = useIsAuthenticated()

  if (!isAuthenticated) {
    return <Navigate to="/login" replace />
  }

  return <>{children}</>
}

const App: React.FC = () => {
  return (
    <AuthProvider>
      <BrowserRouter>
        <div className="min-h-screen bg-background">
          <Routes>
            <Route path="/login" element={<div>Login Page</div>} />
            <Route
              path="/dashboard"
              element={
                <AuthenticatedRoute>
                  <div>Dashboard</div>
                </AuthenticatedRoute>
              }
            />
            <Route path="/" element={<Navigate to="/dashboard" replace />} />
          </Routes>
        </div>
      </BrowserRouter>
    </AuthProvider>
  )
}

export default App
