import {
  createRouter,
  createWebHistory
} from "vue-router";
import HomeView from "../views/user/HomeView.vue";
import AdminLayout from "@/layouts/AdminLayout.vue";
import CrawlView from "../views/admin/CrawlView.vue";
import product from "../views/user/ProductView.vue";
import productprice from "../views/user/ProductPrice.vue";

const routes = [{
    path: "/",
    name: "home",
    component: HomeView,
  },
  {
    path: "/product/:id?", // id category
    name: "product",
    component: product,
    props: true
  },
  {
    path: "/productprice/:id",
    name: "productprice",
    component: productprice,
    props: true
  },
  {
    path: "/admin",
    component: AdminLayout, // Sử dụng AdminLayout cho tất cả các route con
    children: [{
        path: "crawl", // Đường dẫn '/admin/crawl'
        component: CrawlView, // File AdminView.vue
        name: "adminCrawl",
      },
      // Thêm các route con khác của admin tại đây nếu cần
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
  scrollBehavior(to, from, savedPosition) {
    // Nếu có vị trí cuộn được lưu (khi quay lại), nó sẽ cuộn đến vị trí đó
    if (savedPosition) {
      return savedPosition;
    }
    // Mặc định cuộn lên đầu trang
    return {
      top: 0
    };
  },
});

export default router;