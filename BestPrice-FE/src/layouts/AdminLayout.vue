<template>
  <div class="wrapper">
    <AdminSidebar />
    <div class="main">
      <AdminHeader />
      <div id="main-frame">
        <router-view /> <!-- Nội dung sẽ được hiển thị tại đây -->
      </div>
    </div>
  </div>
</template>

<script>
import AdminHeader from "@/components/admin/AdminHeader.vue";
import AdminSidebar from "@/components/admin/AdminSidebar.vue";

export default {
  name: "AdminLayout",
  components: {
    AdminSidebar,
    AdminHeader,
  },
};
</script>

<style scoped>
#main-frame {
  margin-top: 60px;
  margin-left: 70px;
}
.main {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  width: 100%;
  overflow: hidden;
  transition: all 0.35s ease-in-out;
  background-color: #fff;
  min-width: 0;
}
</style>
