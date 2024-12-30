<template>
  <CarouselView></CarouselView>
  <br />
  <section>
    <div class="container-lg">
      <div class="row">
        <span
          class="p-0 fs-3 fst-normal"
          style="color: #207bc1; font-weight: 700; margin: 12px 0"
        >
          Sản phẩm gợi ý hôm nay
        </span>
        <div class="col-md-12">
          <div class="row row-cols-1 row-cols-md-5">
            <!-- cart product -->
            <div
              v-for="product in products.items"
              :key="product.id"
              class="col border border-1"
              style="overflow: hidden"
            >
              <div class="product-item">
                <figure class="figure-wrapper mb-0">
                  <a href="index.html" title="Product Title">
                    <img
                      :src="product.image_url"
                      alt="Product Thumbnail"
                      class="tab-image img-fluid"
                      style="height: 200px; width: 200px; object-fit: fill"
                    />
                  </a>
                </figure>

                <div class="button-area my-1 d-flex justify-content-center">
                  <router-link
                    :to="{
                      name: 'productprice',
                      params: { id: product.id },
                    }"
                    class="nav-link link-dark px-2 mx-3 fs-0_2"
                    style="color: white"
                    aria-current="page"
                    @click="
                      viewProductPrice(
                        product.id,
                        product.name,
                        product.image_url,
                        product.price_from
                      );
                      addLocalStore(product);
                    "
                  >
                    <button
                      class="btn btn-danger rounded-pill text-center align-items-center d-flex"
                      style="height: 26px; font-size: 14px"
                    >
                      So sánh giá
                    </button>
                  </router-link>
                </div>
                <div class="d-flex flex-column text-center">
                  <div class="titleProduct d-flex justify-content-center">
                    <span
                      id="mySpan"
                      class="titlename text-start m-0 fs-6 text-capitalize"
                      style="font-style: normal"
                    >
                      {{ product.name }}
                    </span>
                  </div>

                  <div
                    class="priceitem text-start mt-1 d-flex justify-content-center"
                  >
                    <span class="text-danger my-0"
                      >Giá từ
                      {{ product.price_from.toLocaleString("vi-VN") }} đ</span
                    >
                  </div>
                </div>
              </div>
            </div>
            <!-- cart product -->
          </div>
          <!-- / product-grid -->
        </div>
        <nav aria-label="Page navigation" style="bottom: 0">
          <ul
            class="pagination d-flex align-items-center justify-content-center p-3 m-0"
          >
            <li class="page-item" :class="{ disabled: pageNumber === 1 }">
              <a
                class="page-link"
                href="#"
                aria-label="Previous"
                @click.prevent="changePage(pageNumber - 1)"
              >
                <span aria-hidden="true">&laquo;</span>
                <span class="sr-only">Previous</span>
              </a>
            </li>
            <li
              v-for="page in visiblePages"
              :key="page"
              class="page-item"
              :class="{ active: page === pageNumber }"
            >
              <a class="page-link" href="#" @click.prevent="changePage(page)">{{
                page
              }}</a>
            </li>
            <li class="page-item" :class="{ disabled: products.length == 0 }">
              <a
                class="page-link"
                href="#"
                aria-label="Next"
                @click.prevent="changePage(pageNumber + 1)"
              >
                <span aria-hidden="true">&raquo;</span>
                <span class="sr-only">Next</span>
              </a>
            </li>
          </ul>
        </nav>
      </div>

      <!-- danh muc san pham -->
      <div class="row mb-5">
        <span
          class="p-0 fs-3 fst-normal"
          style="color: #207bc1; font-weight: 700; margin: 12px 0"
        >
          Category
        </span>
        <div class="col-md-12">
          <div class="row row-cols-1 row-cols-md-5">
            <!-- Category Items -->
            <div class="category-item">
              <router-link
                class="nav-link link-dark px-2 mx-3 fs-6"
                style="color: white"
                aria-current="page"
                :to="{ name: 'product', params: { id: 1 } }"
                ><img
                  src="https://asset.websosanh.vn/dist/23a87860d12ab078ca3f.png"
                  alt="Fruits & Veges"
                />
                <p class="category-name fs-6">Điện thoại</p>
              </router-link>
            </div>
            <div class="category-item">
              <router-link
                class="nav-link link-dark px-2 mx-3 fs-6"
                style="color: white"
                aria-current="page"
                :to="{ name: 'product', params: { id: 2 } }"
                ><img
                  src="https://asset.websosanh.vn/dist/49f0b34bf25477cc5b26.png"
                  alt="Fruits & Veges"
                />
                <p class="category-name fs-6">Laptop</p>
              </router-link>
            </div>

            <!-- Category Items -->
          </div>
          <!-- / product-grid -->
        </div>
      </div>
      <!-- danh muc san pham -->

      <!-- san pham gan day -->
      <div class="row mb-5">
        <span
          class="p-0 fs-3 fst-normal"
          style="color: #207bc1; font-weight: 700; margin: 12px 0"
        >
          Sản phẩm bạn vừa xem
        </span>
        <div class="col-md-12">
          <div class="row row-cols-1 row-cols-md-5">
            <!-- cart product -->
            <div
              v-for="product in productsRecenly"
              :key="product.id"
              class="col border border-1"
              style="overflow: hidden"
            >
              <div class="product-item">
                <figure class="figure-wrapper mb-0">
                  <a href="index.html" title="Product Title">
                    <img
                      :src="product.image_url"
                      alt="Product Thumbnail"
                      class="tab-image img-fluid"
                      style="height: 200px; width: 200px; object-fit: fill"
                    />
                  </a>
                </figure>

                <div class="button-area my-1 d-flex justify-content-center">
                  <router-link
                    :to="{
                      name: 'productprice',
                      params: { id: product.id },
                    }"
                    class="nav-link link-dark px-2 mx-3 fs-0_2"
                    style="color: white"
                    aria-current="page"
                    @click="
                      viewProductPrice(
                        product.id,
                        product.name,
                        product.image_url,
                        product.price_from
                      );
                      addLocalStore(product);
                    "
                  >
                    <button
                      class="btn btn-danger rounded-pill text-center align-items-center d-flex"
                      style="height: 26px; font-size: 14px"
                    >
                      Tới nơi bán
                    </button>
                  </router-link>
                </div>
                <div class="d-flex flex-column text-center">
                  <div class="titleProduct d-flex justify-content-center">
                    <span
                      id="mySpan"
                      class="titlename text-start m-0 fs-6 text-capitalize"
                      style="font-style: normal"
                    >
                      {{ product.name }}
                    </span>
                  </div>

                  <div
                    class="priceitem text-start mt-1 d-flex justify-content-center"
                  >
                    <span class="text-danger my-0">Giá từ
                      {{ product.price_from.toLocaleString("vi-VN") }} đ</span>
                  </div>
                </div>
              </div>
            </div>
            <!-- cart product -->
          </div>
          <!-- / product-grid -->
        </div>
      </div>
      <!-- san pham gan day -->
    </div>
  </section>
</template>

<script>
import CarouselView from "@/components/user/CarouselView.vue";

export default {
  name: "HomeView",
  components: {
    CarouselView,
  },
  data() {
    return {
      products: [],
      pageNumber: 1,
      search: "",
      productsRecenly: [],
    };
  },
  mounted() {
    this.fetchProducts();
    this.productsRecenly = JSON.parse(localStorage.getItem("items"));
  },
  computed: {
    visiblePages() {
      if (this.products.length == 0) return;
      const pages = [];
      const startPage = Math.max(1, this.pageNumber - 1);
      const endPage = this.pageNumber + 1;

      for (let i = startPage; i <= endPage; i++) {
        pages.push(i);
      }

      return pages;
    },
  },
  watch: {
    id() {
      this.fetchProducts(); // Gọi lại API khi id thay đổi
    },
    pageNumber() {
      this.fetchProducts(); // Gọi lại API khi id thay đổi
    },
    search() {
      this.fetchProducts(); // Gọi lại API khi id thay đổi
    },
  },
  methods: {
    async fetchProducts() {
      const response = await fetch(
        `https://localhost:7108/api/Product/category?categoryId=0&search=${this.search}&pageNumber=${this.pageNumber}`
      );
      const data = await response.json();
      this.products = data;
    },
    changePage(page) {
      this.pageNumber = page;
      this.fetchProducts();
    },

    viewProductPrice(id, name, imgUrl, price_from) {
      // console.log("huynhphamngoc");
      this.$router.push({
        name: "productprice",
        params: { id },
        query: { name, imgUrl, price_from },
      });
    },
    addLocalStore(product) {
      // Lấy danh sách sản phẩm hiện tại từ localStorage (hoặc khởi tạo mảng rỗng nếu chưa có)
      let items = JSON.parse(localStorage.getItem("items") || "[]");

      // Tìm vị trí của sản phẩm trong danh sách (nếu đã tồn tại)
      const existingIndex = items.findIndex((item) => item.id === product.id);

      // Nếu sản phẩm đã tồn tại, xóa nó khỏi vị trí cũ
      if (existingIndex !== -1) {
        items.splice(existingIndex, 1);
      }

      // Thêm sản phẩm mới hoặc vừa truy cập lên đầu danh sách
      items.unshift(product);

      // Giới hạn danh sách chỉ chứa tối đa 10 sản phẩm
      if (items.length > 5) {
        items = items.slice(0, 5); // Lấy 10 sản phẩm đầu tiên (những sản phẩm mới nhất)
      }

      // Lưu danh sách đã cập nhật vào localStorage
      localStorage.setItem("items", JSON.stringify(items));
    },
  },
};
</script>

<style scoped>
.fs-0_2 {
  font-size: 12.5px;
}
.fs-0_3 {
  font-size: 13px;
}
.product-item {
  padding: 10px;
  overflow: hidden;
  transition: background-color 0.3s ease, transform 0.3s ease,
    box-shadow 0.3s ease; /* Thêm hiệu ứng chuyển đổi */
}
.product-item:hover {
  background-color: #f7f7f7; /* Đổi màu nền khi hover */
  transform: translateY(-5px); /* Di chuyển nhẹ lên trên */
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.1); /* Bóng đổ mạnh hơn */
}
.product-item {
  padding: 10px;
  overflow: hidden; /* Đảm bảo nội dung thừa bị ẩn */
}

.figure-wrapper {
  width: 100%;
  /* Chiều cao cố định cho phần ảnh nếu cần */
  overflow: hidden; /* Đảm bảo ảnh không bị tràn ra ngoài */
  display: flex;
  justify-content: center;
  align-items: center;
}
.titlename {
  font-size: 11px;
  line-height: 1.1;
}
.titleProduct {
}
.priceitem {
  font-weight: bold;
  font-size: 14px;
}
.nav-link:hover {
  color: red !important;
}
.cateName {
  color: #287cc4;
  font-weight: 700;
}

.category-item {
  text-align: center;
}
.category-item img {
  width: 100px;
  height: 100px;
  object-fit: cover;
  border-radius: 50%;
}
.category-name {
  margin-top: 5px;
  font-size: 0.9rem;
  color: #333;
}
</style>
