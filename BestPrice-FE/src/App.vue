<template>
  <div v-if="isUserView">
    <MainHeader />
    <MainFooter />
  </div>
  <div v-else>
    <router-view />
  </div>
</template>

<script>
import MainHeader from "./components/user/MainHeader.vue";
// import HomeView from "./views/user/HomeView.vue";
import MainFooter from "./components/user/MainFooter.vue";

export default {
  name: "App",
  components: {
    MainHeader,
    MainFooter,
  },
  computed: {
    isUserView() {
      // Lấy tên route hiện tại
      const currentRouteName = this.$route.name;
      // Danh sách tên route thuộc thư mục user
      const userRoutes = ["home","productprice","product"]; // Thêm các route khác nếu cần
      return userRoutes.includes(currentRouteName);
    },
  },
};
</script>

<style scoped>
</style>
