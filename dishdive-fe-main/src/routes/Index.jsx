import { RouterProvider, createBrowserRouter } from "react-router-dom";
import { useAuth } from "../provider/AuthProvider.jsx";
import { ProtectedRoute } from "./ProtectedRoute.jsx";
import Error from "../pages/Error.jsx"
import About from "../pages/About.jsx"
import Home from "../pages/Home.jsx"
import Login from "../pages/Login.jsx";
import Logout from "../pages/Logout.jsx";
import Recipes from "../pages/Recipes.jsx"
import Root from "../pages/Root.jsx"

const Routes = () => {
  const { token } = useAuth();

  const routesForPublic = [
    {
      path: "/error",
      element: <Error/>,
    },
    {
      path: "/about-us",
      element: <div>About Us</div>,
    },
  ];

  const routesForAuthenticatedOnly = [
    {
      path: "/",
      element: <ProtectedRoute />,
      children: [
        {
          path: "/",
          element: <div>User Home Page</div>,
        },
        {
          path: "/profile",
          element: <div>User Profile</div>,
        },
        {
          path: "/logout",
          element: <div>Logout</div>,
        },
      ],
    },
  ];

  const routesForNotAuthenticatedOnly = [
    {
      path: "/",
      element: <div>Home Page</div>,
    },
    {
      path: "/login",
      element: <div>Login</div>,
    },
  ];

  const router = createBrowserRouter([
    ...routesForPublic,
    ...(!token ? routesForNotAuthenticatedOnly : []),
    ...routesForAuthenticatedOnly,
  ]);

  return <RouterProvider router={router} />;
};

export default Routes;
