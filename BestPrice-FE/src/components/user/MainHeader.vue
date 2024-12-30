<template>
  <!-- header -->
  <header class="p-1">
    <div class="container">
      <div class="d-flex flex-wrap align-items-center justify-content-between">
        <h1 class="logo-wbside">BestPrice</h1>

        <div class="d-flex align-items-center justify-content-between">
          <div class="position-relative" style="width: 600px">
            <input
              class="form-control form-control-dark rounded-pill pr-5"
              placeholder="Search..."
              aria-label="Search"
              style="height: 40px; font-size: 14px; padding-right: 40px"
              v-model="searchQuery"
              @keyup.enter="submitSearch"
            />
            <i
              class="bi bi-search position-absolute"
              style="
                right: 15px;
                top: 50%;
                transform: translateY(-50%);
                color: #aaa;
              "
            ></i>
          </div>
        </div>

        <div class="">
          <div v-if="userInfo">
            <span class="text-white me-3">
              Xin chào, {{ userInfo.fullName }}
            </span>
            <!-- Kiểm tra nếu RoleId == 2 thì hiển thị nút Admin -->
            <div v-if="userInfo.roleId === 2" style="display: inline">
              <a class="btn btn-info mx-2">Admin</a>
            </div>
            <button type="button" class="btn btn-secondary" @click="logout">
              Đăng xuất
            </button>
          </div>
          <div v-else>
            <button
              type="button"
              class="btn btn-primary"
              data-bs-toggle="modal"
              data-bs-target="#loginModal"
            >
              Đăng nhập
            </button>
          </div>
        </div>
      </div>
    </div>
  </header>
  <!-- header -->

  <!-- Modal chứa form -->
  <div
    class="modal fade"
    id="loginModal"
    tabindex="-1"
    aria-labelledby="loginModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-lg">
      <!-- Tăng kích thước modal -->
      <div class="modal-content">
        <div class="modal-header text-white" style="background-color: #287cc4">
          <!-- Header nổi bật -->
          <h5 class="modal-title" id="loginModalLabel">Đăng nhập / Đăng ký</h5>
          <button
            type="button"
            class="btn-close btn-close-white"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <!-- Navigation Tabs -->
          <ul
            class="nav nav-pills mb-4 justify-content-center"
            id="pills-tab"
            role="tablist"
          >
            <li class="nav-item" role="presentation">
              <button
                class="nav-link active"
                id="tab-login"
                data-bs-toggle="pill"
                data-bs-target="#pills-login"
                type="button"
                role="tab"
                aria-controls="pills-login"
                aria-selected="true"
              >
                <i class="bi bi-box-arrow-in-right"></i> Đăng nhập
              </button>
            </li>
            <li class="nav-item" role="presentation">
              <button
                class="nav-link"
                id="tab-register"
                data-bs-toggle="pill"
                data-bs-target="#pills-register"
                type="button"
                role="tab"
                aria-controls="pills-register"
                aria-selected="false"
              >
                <i class="bi bi-person-plus"></i> Đăng ký
              </button>
            </li>
          </ul>

          <!-- Content -->
          <div class="tab-content" id="pills-tabContent">
            <!-- Login form -->
            <div
              class="tab-pane fade show active"
              id="pills-login"
              role="tabpanel"
              aria-labelledby="tab-login"
            >
              <form>
                <!-- Email input -->
                <div class="form-outline mb-3">
                  <label class="form-label" for="loginUserName"
                    ><i class="bi bi-envelope"></i> Tên đăng nhập</label
                  >
                  <input
                    type="text"
                    id="loginUserName"
                    class="form-control"
                    placeholder="Tên đăng nhập của bạn"
                    ref="username"
                  />
                </div>

                <!-- Password input -->
                <div class="form-outline mb-3">
                  <label class="form-label" for="loginPassword"
                    ><i class="bi bi-lock"></i> Mật khẩu</label
                  >
                  <input
                    type="password"
                    id="loginPassword"
                    class="form-control"
                    placeholder="Nhập mật khẩu của bạn"
                    ref="password"
                  />
                </div>

                <!-- Checkbox -->
                <div class="form-check mb-3">
                  <input
                    class="form-check-input"
                    type="checkbox"
                    id="loginRememberMe"
                  />
                  <label class="form-check-label" for="loginRememberMe">
                    Ghi nhớ tài khoản
                  </label>
                </div>

                <!-- Submit button -->
                <button
                  type="submit"
                  class="btn btn-primary w-100"
                  @click="submitLogin"
                >
                  <i class="bi bi-box-arrow-in-right"></i> Đăng nhập
                </button>
              </form>
            </div>

            <!-- Register form -->
            <div
              class="tab-pane fade"
              id="pills-register"
              role="tabpanel"
              aria-labelledby="tab-register"
            >
              <form>
                <!-- Name input -->
                <div class="form-outline mb-3">
                  <label class="form-label" for="registerUserName"
                    ><i class="bi bi-person"></i>Tên đăng nhập</label
                  >
                  <input
                    required
                    ref="reusername"
                    type="text"
                    id="registerUserName"
                    class="form-control"
                    placeholder="Nhập tên đăng nhập của bạn"
                  />
                </div>
                <!-- Password input -->
                <div class="form-outline mb-3">
                  <label class="form-label" for="registerPassword"
                    ><i class="bi bi-lock"></i> Mật khẩu</label
                  >
                  <input
                    ref="repassword"
                    required
                    type="password"
                    id="registerPassword"
                    class="form-control"
                    placeholder="Tạo mật khẩu"
                  />
                </div>

                <!-- re Password input -->
                <div class="form-outline mb-3">
                  <label class="form-label" for="registerRePassword"
                    ><i class="bi bi-lock"></i> Nhập lại mật khẩu</label
                  >
                  <input
                    ref="rerepassword"
                    required
                    type="password"
                    id="registerRePassword"
                    class="form-control"
                    placeholder="Tạo lại mật khẩu trên"
                  />
                </div>
                <!-- Name input -->
                <div class="form-outline mb-3">
                  <label class="form-label" for="registerName"
                    ><i class="bi bi-person"></i> Họ và Tên</label
                  >
                  <input
                    ref="refullname"
                    required
                    type="text"
                    id="registerName"
                    class="form-control"
                    placeholder="Nhập họ và tên của bạn"
                  />
                </div>

                <!-- Email input -->
                <div class="form-outline mb-3">
                  <label class="form-label" for="registerEmail"
                    ><i class="bi bi-envelope"></i> Email</label
                  >
                  <input
                    ref="reemail"
                    type="email"
                    id="registerEmail"
                    class="form-control"
                    placeholder="Nhập email của bạn"
                  />
                </div>

                <div style="text-align: center; margin-bottom: 12px" class="">
                  <span class="text-danger">{{ errorMessage }}</span>
                </div>

                <!-- Submit button -->
                <!-- @click="submitRegister" -->
                <button
                  @click="submitRegister"
                  type="button"
                  class="btn btn-success w-100"
                >
                  <i class="bi bi-person-plus"></i> Đăng ký
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div
    class="container-fluid bg-light border-bottom d-flex flex-wrap justify-content-center align-items-center container-nav"
  >
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
      categories: [], //Dữ liệu sản phẩm sẽ được lấy từ API hoặc static data
      searchQuery: "",
      userInfo: JSON.parse(localStorage.getItem("userInfo")),
      errorMessage: null,
    };
  },

  mounted() {
    // Thay thế bằng việc gọi API nếu cần
    this.fetchProducts();
  },

  //Khong can dung computed cho localstore cx duoc
  computed: {
    //compute la tinh toan lại gia trị khi giá trị phụ thuộc nó thay đổi
    // Lấy thông tin người dùng từ localStorage (tuc la ham nay duoc goi khi userinfo thay doi gia tri)
    //con Watch thi no se theo doi su thay doi cua 1 gia tri de thuc hien goi mot hanh dong ben ngoi ngaoi nhu goi API, watch khong trả ve 1 gia tri nhu vue
    //Compute khac voi goi la la no tu dong goi con ham la minh phai thuc hien 1 loi goi ham
    //=> khong thuc hien compute cho nay vi khong thu hien tinh taon gi ca
    userInfoFromLocalStorage() {
      const user = this.userInfo;
      return user ? user : null;
    },
  },
  methods: {
    async fetchProducts() {
      const response = await fetch("https://localhost:7108/api/Category");
      const data = await response.json();
      this.categories = data;
    },
    submitSearch() {
      if (this.searchQuery) {
        // Navigate to the search results page with the search query
        console.log("test true");
        this.$router.push({
          name: "product", // name route
          params: { id: 0 },
          query: { search: this.searchQuery },
        });
      }
    },
    async submitLogin() {
      const username = this.$refs.username.value;
      const password = this.$refs.password.value;
      try {
        const response = await fetch(
          `https://localhost:7108/api/Users/check-login?username=${encodeURIComponent(
            username
          )}&password=${encodeURIComponent(password)}`
        );

        if (response.ok) {
          const user = await response.json();
          localStorage.setItem("userInfo", JSON.stringify(user)); // Lưu thông tin người dùng
          alert("Đăng nhập thành công!");
          // console.log(user.FullName);
          // this.$router.push("/dashboard");
        } else if (response.status === 401) {
          alert("Sai tên đăng nhập hoặc mật khẩu!");
        } else {
          console.error("Error:", response.statusText);
          alert("Đã xảy ra lỗi khi đăng nhập.");
        }
      } catch (error) {
        console.error("Fetch error:", error);
        alert("Không thể kết nối đến máy chủ.");
      }
    },
    logout() {
      // console.log(this.userInfo.roleId);
      // Xóa thông tin người dùng khỏi localStorage
      localStorage.removeItem("userInfo");
      this.userInfo = null;
      alert("Bạn chắc chắn đăng xuất.");
    },
    async submitRegister() {
      const userName = this.$refs.reusername.value;
      const password = this.$refs.repassword.value;
      const repassword = this.$refs.rerepassword.value;
      const fullName = this.$refs.refullname.value;
      const address = "string";
      const phoneNumber = "string";
      const roleId = "1";

      const response = await fetch("https://localhost:7108/api/Users");
      const Users = await response.json();
      // Kiểm tra tên đăng nhập
      const userExists = Users.some(
        (user) => user.userName === this.$refs.reusername.value
      );

      if (userExists) {
        this.errorMessage = "Tên đăng nhập đã tồn tại";
        return;
      }

      if (userName == "" || password == "" || fullName == "") {
        this.errorMessage = "Lỗi nhập dữ liệu";
        return;
      }

      if (repassword !== password) {
        console.log(userName + " " + password);
        this.errorMessage = "Nhập lại mật khẩu không chính xác";
        return;
      }

      //du lieu gui len
      const registerForm = {
        userName,
        password,
        fullName,
        address,
        phoneNumber,
        roleId,
      };

      try {
        // Gửi yêu cầu POST đến API để đăng ký tài khoản
        const response = await fetch(
          "https://localhost:7108/api/Users/create-user",
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(registerForm), // Chuyển form đăng ký thành JSON
          }
        );

        const data = await response.json(); // Lấy dữ liệu trả về từ API

        // Kiểm tra nếu đăng ký thành công
        if (response.ok) {
          alert("Đăng ký thành công");
          this.errorMessage = "";
        } else {
          alert("Đã xảy ra lỗi");
          this.errorMessage =
            data.message || "Đã có lỗi xảy ra. Vui lòng thử lại.";
        }
      } catch (error) {
        alert("Loi");
        // Xử lý lỗi khi gửi yêu cầu
        this.errorMessage = "Đã có lỗi xảy ra. Vui lòng thử lại.";
        console.error(error);
      }
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
.logo-wbside {
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
