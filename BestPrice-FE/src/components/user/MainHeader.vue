<template>
  <!-- header -->
  <header class="p-1">
    <div class="container">
      <div class="d-flex flex-wrap align-items-center justify-content-between">

        <h1 class="logo-wbside">BestPrice</h1>

        <div>
          <input
            class="form-control form-control-dark rounded-pill"
            placeholder="Search..."
            aria-label="Search"
            style="height: 40px; width: 600px; font-size: 14px"
          />
        </div>

        <div class="">
          <a
            class="btn-login d-flex align-items-center fs-6"
            href="/admin"
            style="font-size: 14px"
          >
            Đăng nhập
            <i class="fa-solid fa-user ms-2"></i>
          </a>
        </div>
      </div>
    </div>
  </header>
  <!-- header -->

  <!-- navbar view -->
  <div class="container-fluid bg-light border-bottom d-flex flex-wrap justify-content-center align-items-center container-nav">
    <nav
      class="container d-flex flex-wrap justify-content-center align-items-center"
    >
      <div class="d-flex align-items-center">
        <i class="bi bi-list"></i>
        <p class="fs-6 my-0 ms-2 pe-2">Danh mục sản phẩm</p>
        |
      </div>

      <div>
        <ul class="nav mx-0">
          <li class="nav-item">
            <router-link
              class="nav-link link-dark px-2 mx-3 fs-6"
              style="color: white"
              aria-current="page"
              to="/"
              >Home</router-link
            >
          </li>
          <li
            v-for="category in categories"
            :key="category.id"
            class="nav-item"
          >
            <router-link
              class="nav-link link-dark px-2 mx-3 fs-6"
              style="color: white"
              aria-current="page"
              :to="{ name: 'product', params: { id: category.id } }"
              >{{ category.name }}</router-link
            >
          </li>
        </ul>
      </div>
    </nav>
  </div>
  <!-- navbar view -->

  <!-- hien thi thu router -->
  <router-view />
  <!-- hien thi thu router -->
</template>


<script>
// import CarouselView from "@/components/user/CarouselView.vue";

export default {
  name: "MainHeader",
  components: {},
  data() {
    return {
      categories: [], // Dữ liệu sản phẩm sẽ được lấy từ API hoặc static data
    };
  },
  mounted() {
    // Thay thế bằng việc gọi API nếu cần
    this.fetchProducts();
  },
  methods: {
    async fetchProducts() {
      const response = await fetch("https://localhost:7108/api/Category");
      const data = await response.json();
      this.categories = data;
    },
  },
};
</script>

<style scoped>
/* Để gạch chân chữ BestPrice và thay đổi màu */
.partner {
  color: white;
}

/* Để làm cho chữ BestPrice to và đậm hơn */

.highlight-text {
  position: relative;
  display: inline-block;
  font-weight: bold;
  /* Optional: làm cho chữ đậm hơn */
}

/* Để làm cho chữ BestPrice to, đậm và có gạch chân */
.logo {
  font-size: 1rem;
  /* Điều chỉnh kích thước chữ */
  font-weight: bold;
  /* Làm cho chữ đậm */
  text-transform: uppercase;
  /* Biến chữ thành chữ hoa nếu cần */
  position: relative;
  /* Cần để định vị gạch chân */
  color: #fff;
  /* Màu chữ, có thể thay đổi theo ý muốn */
  text-decoration: none;
  /* Bỏ gạch chân mặc định của liên kết */
}
/* CSS */
.form-container {
  display: flex;
}

.custom-search-input {
  border-radius: 0; /* Loại bỏ bo góc ở phần giao */
  border-top-left-radius: 0.25rem; /* Bo góc trên bên trái */
  border-bottom-left-radius: 0.25rem; /* Bo góc dưới bên trái */
}

.custom-search-button {
  border-radius: 0; /* Loại bỏ bo góc ở phần giao */
  border-top-right-radius: 0.25rem; /* Bo góc trên bên phải */
  border-bottom-right-radius: 0.25rem; /* Bo góc dưới bên phải */
}

/* Để tạo gạch chân màu dưới chữ */
.logo::after {
  content: "";
  position: absolute;
  left: 0;
  bottom: 0;
  width: 100%;
  height: 5px;
  /* Độ dày của gạch chân */
  background-color: #ffd43b;
  /* Màu của gạch chân */
  border-radius: 2px;
  /* Bo góc gạch chân nếu cần */
  bottom: 0.2px;
}

/* Để làm cho biểu tượng lớn hơn */
.icon-large {
  font-size: 1.5rem;
  /* Tùy chỉnh kích thước lớn hơn */
}

/* Căn chỉnh các thành phần trong header */
.btn-icon {
  background: none;
  border: none;
  color: inherit;
  padding: 0;
  cursor: pointer;
  font-size: 1.5rem;
}

/* Điều chỉnh chiều cao và padding của navbar */
.custom-navbar {
  height: 80px;
  padding: 10px 20px;
}

/* Màu nền cho navbar */
.bg-color {
  height: auto;
  background-color: #2596be;
}

/* Nút tìm kiếm */
.btn-search {
  background-color: #906404;
  flex: 0 0 10%;
  height: 40px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.category-item {
  color: white;
  text-decoration: none;
  cursor: pointer;
  transition: color 0.3s ease;
}

.category-item.selected {
  color: #007bff;
  /* Màu chữ khi mục được chọn */
}

/* Input tìm kiếm */
.form-control {
  flex: 1;
  height: 40px;
}

/* Điều chỉnh kích thước phần chứa form */
.form-container {
  width: 50%;
  margin: 0 auto;
  box-sizing: border-box;
}

/* Nút đăng nhập */
.btn-login {
  text-decoration: none;
  color: white;
  font-size: 1.2rem;
}

/* Điều chỉnh menu catalog */
.catalog-menu {
  background-color: #fff;
  border-top: 1px solid #ddd;
  padding: 10px 0;
}

.catalog-menu .nav-link {
  color: #333;
  padding: 5px 10px;
  font-size: 1.1rem;
}

.catalog-menu .nav-link:hover {
  background-color: #f8f9fa;
  border-radius: 5px;
}

/* Điều chỉnh cho màn hình nhỏ */
@media (max-width: 767px) {
  .catalog-menu {
    background-color: #fff;
    padding: 10px;
  }

  .partner,
  .btn-login {
    display: block;
    padding: 10px;
  }

  .custom-navbar {
    height: auto;
    padding: 10px;
  }

  .form-container {
    width: 100%;
    margin: 0;
  }

  .btn-login {
    margin-top: 10px;
    width: 100%;
    text-align: center;
  }
}

/* Điều chỉnh cho màn hình lớn */
@media (min-width: 768px) {
  .form-container {
    width: 50%;
  }

  .container-fluid {
    display: flex;
  }

  .btn-login {
    width: auto;
    text-align: left;
  }
}
.logo-wbside{
  color: white;
}
header {
  background-color: #287cc4;
}
.container {
}
.navbar-expand-lg .navbar-nav .nav-link {
  color: white;
}
.fs-0_2 {
  font-size: 12.5px;
}
.fs-0_3 {
  font-size: 13px;
}
.container-nav {
  height: 55px;
}
</style>
