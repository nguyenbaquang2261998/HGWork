import DashboardLayout from "@/pages/Layout/DashboardLayout.vue";

import Dashboard from "@/pages/Dashboard.vue";
import UserProfile from "@/pages/UserProfile.vue";
import Task from "@/pages/Task/TaskForm.vue";
import ProjectTable from "@/pages/Project/ProjectTable.vue";
import TaskTable from "@/pages/Task/TaskTable.vue";
import UserTable from "@/pages/UserProfile/UserTable.vue";
import UserForm from "@/pages/UserProfile/UserForm.vue";
import HomePage from "@/pages/Home/HomePage.vue";
import LoginPage from "@/pages/Login.vue";
import TableList from "@/pages/TableList.vue";
import Typography from "@/pages/Typography.vue";
import Icons from "@/pages/Icons.vue";
import Maps from "@/pages/Maps.vue";
import Notifications from "@/pages/Notifications.vue";
import UpgradeToPRO from "@/pages/UpgradeToPRO.vue";

const routes = [
  {
    path: "/",
    component: DashboardLayout,
    redirect: "/dashboard",
    children: [
      {
        path: "home",
        name: "Trang chủ",
        component: HomePage,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user') == 'true') {
            console.log(localStorage.getItem('user'));
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "dashboard",
        name: "Dashboard",
        component: Dashboard,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "createproject",
        name: "Dự án",
        component: UserProfile,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "listproject",
        name: "Danh sách dự án",
        component: ProjectTable,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "createtask",
        name: "Công việc",
        component: Task,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "listtasks/:id",
        name: "Danh sách công việc",
        component: TaskTable,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "listuser",
        name: "Danh sách tài khoản",
        component: UserTable,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "createuser",
        name: "Tạo tài khoản",
        component: UserForm,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "table",
        name: "Table List",
        component: TableList,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "typography",
        name: "Typography",
        component: Typography,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "icons",
        name: "Icons",
        component: Icons,
        props: true,
        beforeEnter: (to, from, next) => {
          if(localStorage.getItem('user')) {
            console.log('co quyen truy cap task');
            next() // Take you to /something
          } else {
            console.log(localStorage.getItem('user'));
              // If params.blah is blank or in your case, does not have permission, redirect back to the home page
            next({ name: 'Login' }) 
          }
        }
      },
      {
        path: "maps",
        name: "Maps",
        meta: {
          hideFooter: true,
        },
        component: Maps,
      },
      {
        path: "notifications",
        name: "Notifications",
        component: Notifications,
      },
      {
        path: "upgrade",
        name: "Upgrade to PRO",
        component: UpgradeToPRO,
      },
      {
        path: "login",
        name: "Login",
        component: LoginPage,
      },
    ],
  }
];

export default routes;
