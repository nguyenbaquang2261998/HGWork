<template>
  <div class="wrapper" :class="{ 'nav-open': $sidebar.showSidebar }">
    <notifications></notifications>

    <side-bar v-if="isLogin == true" :sidebar-item-color="sidebarBackground" :sidebar-background-image="sidebarBackgroundImage">
      <mobile-menu slot="content"></mobile-menu>
      <sidebar-link to="/home">
        <md-icon>home</md-icon>
        <p>Trang chủ</p>
      </sidebar-link>
      <sidebar-link to="/mytask/1/0">
        <md-icon>event</md-icon>
        <p>Công việc của tôi</p>
      </sidebar-link>
      <sidebar-link v-if="isAdmin == 'true'" to="/createproject">
        <md-icon>note_add</md-icon>
        <p>Tạo Dự án</p>
      </sidebar-link>
      <sidebar-link to="/listproject">
        <md-icon>queue_play_next</md-icon>
        <p>Quản lý dự án</p>
      </sidebar-link>
      <sidebar-link to="/createtask">
        <md-icon>add_task</md-icon>
        <p>Tạo công việc</p>
      </sidebar-link>
      <sidebar-link v-if="isAdmin == 'true'" to="/listtasks/0">
        <md-icon>checklist</md-icon>
        <p>Danh sách công việc</p>
      </sidebar-link>
      <sidebar-link to="/dashboard">
        <md-icon>flag</md-icon>
        <p>Báo cáo</p>
      </sidebar-link>
      <sidebar-link to="/notifications">
        <md-icon>notifications</md-icon>
        <p>Thông báo</p>
      </sidebar-link>
      <sidebar-link v-if="isAdmin == 'true'" to="/listuser">
        <md-icon>people_outline</md-icon>
        <p>Danh sách tài khoản</p>
      </sidebar-link>
      <sidebar-link v-if="isAdmin == 'true'" to="/createuser">
        <md-icon>person_add_alt</md-icon>
        <p>Thêm tài khoản</p>
      </sidebar-link>
      <md-button style="background-color: coral !important; position: absolute!important; width: 100%!important;bottom: 10px!important;" @click="$event => logout()" class="active-pro">
        <md-icon >logout</md-icon>
        <p style="margin-right: 15px;">Đăng xuất</p>
      </md-button>
    </side-bar>

    <div class="main-panel">
      <top-navbar></top-navbar>

      <!-- <fixed-plugin
        :color.sync="sidebarBackground"
        :image.sync="sidebarBackgroundImage"
      >
      </fixed-plugin> -->

      <dashboard-content> </dashboard-content>

      <content-footer v-if="!$route.meta.hideFooter"></content-footer>
    </div>
  </div>
</template>

<script>
import TopNavbar from "./TopNavbar.vue";
// import ContentFooter from "./ContentFooter.vue";
import DashboardContent from "./Content.vue";
import MobileMenu from "@/pages/Layout/MobileMenu.vue";
// import FixedPlugin from "./Extra/FixedPlugin.vue";

export default {
  components: {
    TopNavbar,
    DashboardContent,
    // ContentFooter,
    MobileMenu,
    // FixedPlugin,
  },
  data() {
    return {
      sidebarBackground: "green",
      sidebarBackgroundImage: require("@/assets/img/sidebar-2.jpg"),
      isAdmin: false,
      isLogin: false
    };
  },
  created() {
    this.isAdmin = localStorage.getItem('user');

    if (localStorage.getItem('user')) {
      this.isLogin = true;
    }
    console.log(this.isAdmin);
  },
  methods:{
    logout(){
      this.isLogin = false;
      localStorage.setItem('user', undefined);
      location.href = "http://localhost:8080/#/login";
    },
  }
};
</script>
