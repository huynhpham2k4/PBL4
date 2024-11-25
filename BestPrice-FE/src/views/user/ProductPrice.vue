<template>
  <br />
  <section class="py-2">
    <div class="container">
      <div class="row gx-5 d-flex justify-content-center align-items-center">
        <aside class="col-lg-4">
          <div
            class="border rounded-4 mb-3 d-flex justify-content-center align-items-center"
            style="height: 400px; width: 400px"
          >
            <a
              data-fslightbox="mygalley"
              class="rounded-4"
              target="_blank"
              data-type="image"
              :href="productImgUrl"
            >
              <img
                style="
                  max-width: 100%;
                  max-height: 100%;
                  max-width: 100%;
                  margin: auto;
                  object-fit: cover;
                "
                class="rounded-4"
                :src="productImgUrl"
              />
            </a>
          </div>

          <!-- thumbs-wrap.// -->
          <!-- gallery-wrap .end// -->
        </aside>
        <main class="col-lg-8">
          <div class="ps-lg-3">
            <h3 class="title text-dark text-capitalize">
              {{ productName }} <br />
            </h3>
            <div class="priceitem text-start mt-1">
              <span class="text-danger my-3 fw-bolder"
                >Giá từ {{ productPriceFrom.toLocaleString("vi-VN") }} đ</span
              >
            </div>

            <div class="d-flex flex-row my-3">
              <div class="text-warning mb-1 me-2">
                <i class="fa fa-star"></i>
                <i class="fa fa-star"></i>
                <i class="fa fa-star"></i>
                <i class="fa fa-star"></i>
                <i class="fas fa-star-half-alt"></i>
                <span class="ms-1"> 4.5 </span>
              </div>
              <span class="text-muted"
                ><i class="fas fa-shopping-basket fa-sm mx-1"></i>154
                orders</span
              >
              <span class="text-success ms-2">In stock</span>
            </div>

            <!-- product price -->
            <div class="row mt-4">
              <div class="col-md-12">
                <div
                  v-if="productPrices.length"
                  class="row row-cols-1 row-cols-md-4 g-2"
                >
                  <div
                    v-for="productPrice in productPrices.slice(0, 4)"
                    :key="productPrice.id"
                    class="productPrice col"
                  >
                    <div class="card h-100 text-center">
                      <span
                        class="compare-ads-badge fw-bolder"
                        style="
                          color: white;
                          background-color: #3cb312;
                          border-top-left-radius: 5px;
                          border-top-right-radius: 5px;
                        "
                        >Đề xuất</span
                      >

                      <div
                        class="bg-gradient h-40 d-flex justify-content-center align-items-center"
                        style="height: 70px"
                      >
                        <img
                          :src="productPrice.website.urlLogo"
                          alt="BVT Mobile Logo"
                          style="
                            height: 55px;
                            width: 127px;
                            object-fit: contain;
                          "
                        />
                      </div>

                      <span class="card-title text-danger fw-bolder mb-3 fs-5"
                        >{{
                          productPrice.price.toLocaleString("vi-VN")
                        }}
                        đ</span
                      >

                      <div class="mb-3">
                        <a
                          :href="productPrice.url"
                          class="btn btn-danger rounded-pill btn-sm"
                          style="padding: 3px 20px"
                          target="_blank"
                          >Xem ngay</a
                        >
                      </div>
                    </div>
                  </div>
                </div>
                <div v-else>Loading...</div>
              </div>
            </div>
            <!-- product price -->
          </div>
        </main>
      </div>
    </div>
  </section>
  <!-- content -->

  <section class="bg-light border-top py-4">
    <div class="container">
      <div class="row gx-4">
        <div class="col-lg-8 mb-4">
          <div class="border rounded-2 px-3 py-2 bg-white">
            <!-- Pills navs -->
            <ul
              class="nav nav-pills nav-justified mb-3"
              id="ex1"
              role="tablist"
            >
              <li class="nav-item d-flex" role="presentation">
                <a
                  class="nav-link d-flex align-items-center justify-content-center w-100 active"
                  id="ex1-tab-1"
                  data-bs-toggle="pill"
                  href="#ex1-pills-1"
                  role="tab"
                  aria-controls="ex1-pills-1"
                  aria-selected="true"
                  >So sánh giá</a
                >
              </li>
              <li class="nav-item d-flex" role="presentation">
                <a
                  class="nav-link d-flex align-items-center justify-content-center w-100"
                  id="ex1-tab-2"
                  data-bs-toggle="pill"
                  href="#ex1-pills-2"
                  role="tab"
                  aria-controls="ex1-pills-2"
                  aria-selected="false"
                  >Thông tin sản phẩn</a
                >
              </li>
              <li class="nav-item d-flex" role="presentation">
                <a
                  class="nav-link d-flex align-items-center justify-content-center w-100"
                  id="ex1-tab-3"
                  data-bs-toggle="pill"
                  href="#ex1-pills-3"
                  role="tab"
                  aria-controls="ex1-pills-3"
                  aria-selected="false"
                  >Thông số kỹ thuật</a
                >
              </li>
            </ul>
            <!-- Pills navs -->

            <!-- Pills content -->
            <div class="tab-content" id="ex1-content">
              <div
                class="tab-pane fade show active"
                id="ex1-pills-1"
                role="tabpanel"
                aria-labelledby="ex1-tab-1"
              >
                <table class="table border mt-3 mb-2">
                  <tr
                    v-for="productPrice in productPrices.slice(0)"
                    :key="productPrice.id"
                    class="d-flex justify-content-between align-items-center border-bottom"
                  >
                    <div>
                      <img
                        :src="productPrice.website.urlLogo"
                        alt="BVT Mobile Logo"
                        style="height: 80px; width: 135px; object-fit: contain"
                      />
                    </div>
                    <div
                      style="
                        display: flex;
                        justify-content: center;
                        width: 350px;
                      "
                    >
                      <span class="fs-5 text-capitalize">{{
                        productPrice.product.name
                      }}</span>
                    </div>
                    <div>
                      <span class="card-title text-danger fw-bolder mb-3 fs-5"
                        >{{
                          productPrice.price.toLocaleString("vi-VN")
                        }}
                        đ</span
                      >
                    </div>
                    <div class="px-3">
                      <a
                        :href="productPrice.url"
                        class="btn btn-danger rounded-pill btn-sm"
                        style="padding: 3px 20px"
                        target="_blank"
                        >Xem ngay</a
                      >
                    </div>
                  </tr>
                </table>
              </div>
              <div
                class="tab-pane fade mb-2"
                id="ex1-pills-2"
                role="tabpanel"
                aria-labelledby="ex1-tab-2"
              >
                Tab content or sample information now <br />
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut
                enim ad minim veniam, quis nostrud exercitation ullamco laboris
                nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor
                in reprehenderit in voluptate velit esse cillum dolore eu fugiat
                nulla pariatur. Excepteur sint occaecat cupidatat non proident,
                sunt in culpa qui officia deserunt mollit anim id est laborum.
                Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut
                enim ad minim veniam, quis nostrud exercitation ullamco laboris
                nisi ut aliquip ex ea commodo
              </div>
              <div
                class="tab-pane fade mb-2"
                id="ex1-pills-3"
                role="tabpanel"
                aria-labelledby="ex1-tab-3"
              >
                Another tab content or sample information now <br />
                Dolor sit amet, consectetur adipisicing elit, sed do eiusmod
                tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
                minim veniam, quis nostrud exercitation ullamco laboris nisi ut
                aliquip ex ea commodo consequat. Duis aute irure dolor in
                reprehenderit in voluptate velit esse cillum dolore eu fugiat
                nulla pariatur. Excepteur sint occaecat cupidatat non proident,
                sunt in culpa qui officia deserunt mollit anim id est laborum.
              </div>
            </div>
            <!-- Pills content -->
          </div>
        </div>
        <div class="col-lg-4">
          <div class="px-0 border rounded-2 shadow-0">
            <div class="card">
              <div class="card-body">
                <h5 class="card-title">Tin tức liên quan</h5>
                <div
                  class="tab-pane fade show active"
                  id="ex1-pills-1"
                  role="tabpanel"
                  aria-labelledby="ex1-tab-1"
                >
                  <p class="fw-semibold">
                    Giá iPhone 16 series VN/A giảm hàng loạt chỉ sau hơn 1 tháng
                    bán ra tại Việt Nam
                  </p>
                  <div>
                    Điện thoại iPhone 16 series chính thức bán ra tại thị trường
                    Việt Nam từ ngày 27/12/2024, và cho tới hiện tại là chỉ hơn
                    1 tháng được bán ra trên thị trường nhưng tất cả các phiên
                    bản iPhone 16 đã giảm giá hàng loạt.
                  </div>
                  <table class="table border mt-3 mb-2">
                    <tr>
                      <th class="py-2">Màn hình:</th>
                      <td class="py-2">
                        13.3-inch LED-backlit display with IPS
                      </td>
                    </tr>
                    <tr>
                      <th class="py-2">Bộ vi xử lý:</th>
                      <td class="py-2">2.3GHz dual-core Intel Core i5</td>
                    </tr>
                    <tr>
                      <th class="py-2">Chất lượng camera:</th>
                      <td class="py-2">720p FaceTime HD camera</td>
                    </tr>
                    <tr>
                      <th class="py-2">Bộ nhớ:</th>
                      <td class="py-2">8 GB RAM hoặc 16 GB RAM</td>
                    </tr>
                    <tr>
                      <th class="py-2">Đồ họa:</th>
                      <td class="py-2">Intel Iris Plus Graphics 640</td>
                    </tr>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  props: ["id"],
  data() {
    return {
      productPrices: [],
    };
  },
  mounted() {
    fetch("https://localhost:7108/api/ProductPrice/" + this.id)
      .then((res) => res.json())
      .then((data) => (this.productPrices = data))
      .catch((err) => console.log(err.message));
    console.log(this.productImgUrl);
  },
  computed: {
    productName() {
      return this.$route.query.name;
    },
    productImgUrl() {
      return this.$route.query.imgUrl;
    },
    productPriceFrom() {
      return Number(this.$route.query.price_from);
    },
  },
};
</script>

<style>
.icon-hover:hover {
  border-color: #3b71ca !important;
  background-color: white !important;
  color: #3b71ca !important;
}

.icon-hover:hover i {
  color: #3b71ca !important;
}
</style>