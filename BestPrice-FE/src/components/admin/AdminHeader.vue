<template>
  <nav class="navbar navbar-expand px-4 py-3 fixed-top">
    <form action="#" class="d-none d-sm-inline-block"></form>
    <div class="navbar-collapse collapse">
      <ul class="navbar-nav ms-auto">
        <li class="nav-item dropdown">
          <a href="#" data-bs-toggle="dropdown" class="nav-icon pe-md-0">
            <img
              src="@/assets/image/account.png"
              class="avatar img-fluid"
              alt=""
            />
          </a>
          <div class="dropdown-menu dropdown-menu-end rounded">
            <!-- Nội dung dropdown -->
          </div>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {
  name: "AdminHeader",
};
</script>

<style scoped>
.navbar {
  background-color: #dad8d8b0;
  box-shadow: 0 0 2rem 0 rgba(65, 66, 66, 0.1);
  z-index: 999;
}

.navbar-expand .navbar-collapse {
  min-width: 200px;
}

.avatar {
  height: 40px;
  width: 40px;
}
</style>
