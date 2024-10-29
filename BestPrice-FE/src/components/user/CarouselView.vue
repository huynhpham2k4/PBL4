<template>
  <br />
  <div
    id="carouselExampleIndicators"
    class="carousel slide"
    data-bs-ride="true"
  >
    <div class="carousel-indicators">
      <button
        type="button"
        data-bs-target="#carouselExampleIndicators"
        data-bs-slide-to="0"
        class="active"
        aria-current="true"
        aria-label="Slide 1"
      ></button>
      <button
        type="button"
        data-bs-target="#carouselExampleIndicators"
        data-bs-slide-to="1"
        aria-label="Slide 2"
      ></button>
      <button
        type="button"
        data-bs-target="#carouselExampleIndicators"
        data-bs-slide-to="2"
        aria-label="Slide 3"
      ></button>
      <button
        type="button"
        data-bs-target="#carouselExampleIndicators"
        data-bs-slide-to="3"
        aria-label="Slide 4"
      ></button>
    </div>
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img
          src="https://img.websosanh.vn/v2/users/bpi/images/nb134oiqb8jf2.jpg?compress=85"
          class="d-block img-item"
          alt="..."
        />
      </div>
      <div class="carousel-item">
        <img
          src="https://img.websosanh.vn/v2/users/bpi/images/5no3gvl0jnin8.jpg?compress=85"
          class="d-block img-item"
          alt="..."
        />
      </div>
      <div class="carousel-item">
        <img
          src="https://img.websosanh.vn/v2/users/bpi/images/xx60zzy4had1o.jpg?compress=85"
          class="d-block img-item"
          alt="..."
        />
      </div>
      <div class="carousel-item">
        <img
          src="https://img.websosanh.vn/v2/users/bpi/images/2btsydc0z2dlj.jpg?compress=85"
          class="d-block img-item"
          alt="..."
        />
      </div>
    </div>
    <button
      class="carousel-control-prev"
      type="button"
      data-bs-target="#carouselExampleIndicators"
      data-bs-slide="prev"
    >
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button
      class="carousel-control-next"
      type="button"
      data-bs-target="#carouselExampleIndicators"
      data-bs-slide="next"
    >
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
  </div>
</template>
<script>
export default {
  name: "CarouselView",
};
</script>

<style scoped>
.carousel-item {
  height: 380px;
}
.img-item {
  height: 100%;
  width: 100%;
  border: 1px solid;
  border-radius: 3px;
  border-color: gray;
  object-fit: fill;
}
#carouselExampleIndicators {
}
</style>