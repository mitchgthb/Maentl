import type React from "react"
import { Routes, Route, Navigate } from "react-router-dom"
import { useIsAuthenticated } from "@azure/msal-react"
import DocumentsView from "@/pages/DocumentsView"
import CustomersView from "@/pages/CustomersView"
import ProjectsView from "@/pages/ProjectsView"
import WorksView from "@/pages/WorksView"
import LoginView from "@/pages/LoginView"

// Protected Route wrapper component
const AuthenticatedRoute: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const isAuthenticated = useIsAuthenticated()

  // if (!isAuthenticated) {
  //   return <Navigate to="/login" replace />
  // }

  return <>{children}</>
}

const AppRoutes: React.FC = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/documents" replace />} />

      <Route
        path="/documents"
        element={
          <AuthenticatedRoute>
            <DocumentsView />
          </AuthenticatedRoute>
        }
      />

      <Route
        path="/customers"
        element={
          <AuthenticatedRoute>
            <CustomersView />
          </AuthenticatedRoute>
        }
      />

      <Route
        path="/projects"
        element={
          <AuthenticatedRoute>
            <ProjectsView />
          </AuthenticatedRoute>
        }
      />

      <Route
        path="/login"
        element={
          <AuthenticatedRoute>
            <WorksView />
          </AuthenticatedRoute>
        }
      />
    </Routes>
  )
}

export default AppRoutes
