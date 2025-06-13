"use client"

import type React from "react"
import { createContext, useContext, useEffect, useState, type ReactNode } from "react"
import type { AccountInfo } from "@azure/msal-browser"
import { isAuthenticated, getAccount } from "../services/authService"

interface AuthContextType {
  isAuthenticated: boolean
  account: AccountInfo | null
  loading: boolean
}

const AuthContext = createContext<AuthContextType | undefined>(undefined)

export const useAuth = (): AuthContextType => {
  const context = useContext(AuthContext)
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider")
  }
  return context
}

interface AuthProviderProps {
  children: ReactNode
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [authenticated, setAuthenticated] = useState<boolean>(false)
  const [account, setAccount] = useState<AccountInfo | null>(null)
  const [loading, setLoading] = useState<boolean>(true)

  useEffect(() => {
    const checkAuth = async () => {
      try {
        const authStatus = await isAuthenticated()
        setAuthenticated(authStatus)

        if (authStatus) {
          const userAccount = await getAccount()
          setAccount(userAccount)
        }
      } catch (error) {
        console.error("Auth check failed:", error)
      } finally {
        setLoading(false)
      }
    }

    checkAuth()
  }, [])

  return (
    <AuthContext.Provider value={{ isAuthenticated: authenticated, account, loading }}>{children}</AuthContext.Provider>
  )
}
