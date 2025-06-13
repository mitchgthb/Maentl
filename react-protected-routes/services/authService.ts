import type { AccountInfo, AuthenticationResult } from "@azure/msal-browser"
import { pca } from "./msalConfig"

const loginRequest = {
  scopes: ["User.Read"],
}

export const login = async (): Promise<AuthenticationResult | null> => {
  try {
    const response = await pca.loginPopup(loginRequest)
    return response
  } catch (error) {
    console.error("Login failed:", error)
    return null
  }
}

export const logout = async (): Promise<void> => {
  try {
    await pca.logoutPopup()
  } catch (error) {
    console.error("Logout failed:", error)
  }
}

export const getAccount = async (): Promise<AccountInfo | null> => {
  const accounts = pca.getAllAccounts()
  return accounts.length > 0 ? accounts[0] : null
}

export const isAuthenticated = async (): Promise<boolean> => {
  const accounts = pca.getAllAccounts()
  return accounts.length > 0
}

export const getAccessToken = async (): Promise<string | null> => {
  try {
    const accounts = pca.getAllAccounts()
    if (accounts.length === 0) return null

    const response = await pca.acquireTokenSilent({
      ...loginRequest,
      account: accounts[0],
    })
    return response.accessToken
  } catch (error) {
    console.error("Token acquisition failed:", error)
    return null
  }
}
