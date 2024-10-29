<template>
  <br />
  <section>
    <div class="container-lg">
      <div>
        <p class="m-0 p-0 fs-3 fst-normal mb-3">{{ nameCategory?.name }}</p>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="row row-cols-1 row-cols-md-5">
            <!-- cart product -->
            <div
              v-for="product in products"
              :key="product.id"
              class="col border border-1"
              style="overflow: hidden"
            >
              <div class="product-item">
                <figure class="figure-wrapper mb-0">
                  <a href="index.html" title="Product Title">
                    <img
                      :src="product.imageUrl"
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
                        product.imageUrl
                      )
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
                    <span class="text-danger my-0">Giá từ 17.500.000 đ</span>
                  </div>
                </div>
              </div>
            </div>
            <!-- cart product -->
          </div>
          <!-- / product-grid -->
        </div>
      </div>
    </div>
  </section>

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
</template>

<script>
export default {
  name: "ProductView",
  props: ["id"],
  data() {
    return {
      products: [],
      pageNumber: 1,
      search: "",
      nameCategory: null,
    };
  },
  mounted() {
    this.fetchProducts();
    this.fetchNameCategory();
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

    getNameCategory() {
      return this.nameCategory;
    },
  },
  watch: {
    id() {
      this.fetchProducts(); // Gọi lại API khi id thay đổi
      this.fetchNameCategory();
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
        `https://localhost:7108/api/Product/category?categoryId=${this.id}&search=${this.search}&pageNumber=${this.pageNumber}`
      );
      const data = await response.json();
      this.products = data;
    },
    changePage(page) {
      this.pageNumber = page;
      this.fetchProducts();
    },

    async fetchNameCategory() {
      const response = await fetch(
        `https://localhost:7108/api/Category/${this.id}`
      );
      const data = await response.json();
      this.nameCategory = data;
    },

    viewProductPrice(id, name, imgUrl) {
      // console.log("huynhphamngoc");
      this.$router.push({
        name: "productprice",
        params: { id },
        query: { name, imgUrl },
      });
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
</style>