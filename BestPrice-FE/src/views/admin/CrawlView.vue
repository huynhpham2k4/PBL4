<template>
<div class="container mt-4">
    <div class="column ">
        <!-- Form to input crawl details -->
        <div class="col-md-12">
            <div class="card" style="height: 600px; overflow: hidden;">
                <div class="card-header text-white d-flex justify-content-center align-items-center">
                    <h3 class="mb-0">Crawl dữ liệu</h3>
                </div>
                <div class="card-body" style="overflow-y: auto;">
                    <form @submit.prevent="submitCrawlForm">
                        <div id="accordionExample" class="accordion">
                            <div v-for="(data, index) in formData" :key="index" class="accordion-item">
                                <!-- Wrapper for header and remove button -->
                                <div class="d-flex align-items-center">

                                    <!-- Accordion Header -->
                                    <h2 class="accordion-header flex-grow-1" :id="'heading' + index">
                                        <button class="accordion-button" type="button" :data-bs-toggle="'collapse'" :data-bs-target="'#collapse' + index" :aria-expanded='true' :aria-controls="'collapse' + index">
                                            {{ data.site_name || 'Nhập thông tin cần lấy dữ liệu' }}
                                        </button>
                                    </h2>
                                    <!-- Remove Button -->
                                    <button type="button" class="btn btn-danger m-2" @click="removeForm(index)">
                                        Remove
                                    </button>
                                </div>
                                <div :id="'collapse' + index" class="accordion-collapse collapse show" :aria-labelledby="'heading' + index">
                                    <div class="accordion-body">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label :for="'site_name_' + index">Site Name</label>
                                                    <input type="text" v-model="data.site_name" class="form-control" :id="'site_name_' + index" required>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label :for="'url_' + index">URL</label>
                                                    <input type="text" v-model="data.url" class="form-control" :id="'url_' + index" required>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label :for="'category_' + index">Category</label>
                                                    <select v-model="data.category_id" class="form-control" :id="'category_' + index">
                                                        <option :value="1">Điện thoạidfsdfsdf</option>
                                                        <option :value="2">Laptop</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label :for="'name_selector_' + index">Name Selector</label>
                                                    <input type="text" v-model="data.selectors.name_selector" class="form-control" :id="'name_selector_' + index">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label :for="'price_selector_' + index">Price Selector</label>
                                                    <input type="text" v-model="data.selectors.price_selector" class="form-control" :id="'price_selector_' + index">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label :for="'link_selector_' + index">Link Selector</label>
                                                    <input type="text" v-model="data.selectors.link_selector" class="form-control" :id="'link_selector_' + index">
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label :for="'image_selector_' + index">Image Selector</label>
                                                    <input type="text" v-model="data.selectors.image_selector" class="form-control" :id="'image_selector_' + index">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="text-center mt-4">
                            <button type="button" class="btn btn-secondary me-3" @click="addForm">
                                Add Another
                            </button>
                            <button type="submit" class="btn btn-primary">
                                Crawl Data
                            </button>
                        </div>
                    </form>

                </div>
            </div>
        </div>
        <div class="col-md-12 ">
            <div v-if="crawlStatus === 'loading'">Đang lấy dữ liệu...</div>
            <div v-if="crawlStatus === 'success'">Thành công!</div>
            <div v-if="crawlStatus === 'error'">Lấy dữ liệu thất bại!</div>
        </div>
        <div class="col-md-12">
            <div class="card" style="height: 600px; display: flex; flex-direction: column;">
                <div class="card-header  text-white d-flex justify-content-center align-items-center">
                    <h3 class="mb-0">Thông tin sản phẩm lấy dữ liệu được</h3>
                </div>
                <div class="card-body" style="flex: 1; overflow-y: auto;">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th style="width: 20%">Tên sản phẩm</th>
                                <th style="width: 20%">Link sản phẩm</th>
                                <th style="width: 15%">Giá sản phẩm</th>
                                <th style="width: 15%">Hình ảnh</th>
                                <th style="width: 10%"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(product, index) in statusLog[0]" :key="index">
                                <!-- Tên sản phẩm -->
                                <td>
                                    <div v-if="!product.isEditing">
                                        {{ product.product_name }}
                                    </div>
                                    <input v-if="product.isEditing" v-model="product.product_name" class="form-control  text-black border-0" />
                                </td>

                                <!-- Link sản phẩm với chế độ xem và chỉnh sửa -->
                                <td class="text-truncate" style="max-width: 200px;">
                                    <div v-if="!product.isEditing">
                                        <a :href="product.product_link" target="_blank">link sản phẩm</a>
                                    </div>
                                    <div v-else>
                                        <input v-model="product.product_link" class="form-control" />
                                    </div>
                                </td>

                                <!-- Giá sản phẩm -->
                                <td>{{ product.product_price }}</td>

                                <!-- Hình ảnh sản phẩm -->
                                <td>
                                    <div v-if="!product.isEditing">
                                        <img :src="product.product_image" alt="Product Image" style="width: 50px;" />
                                    </div>
                                    <div v-else>
                                        <input v-model="product.product_image" class="form-control" />
                                    </div>
                                </td>

                                <!-- Nút hành động chỉnh sửa và xóa -->
                                <td>
                                    <button class="btn btn-primary btn-sm" @click="product.isEditing = !product.isEditing">
                                        <i class="fas fa-edit" v-if="!product.isEditing"></i>
                                        <i class="fas fa-save" v-else></i>
                                    </button>
                                    <button class="btn btn-danger btn-sm" @click="deleteProduct(product)">
                                        <i class="fas fa-trash"></i>
                                    </button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <!-- Nút lưu tất cả các sản phẩm ở cuối -->
                <div class="card-footer d-flex justify-content-center" style="position: sticky; bottom: 0; background-color: white;">
                    <button @click="saveCrawledData" class="btn btn-success w-20">Lưu tất cả sản phẩm</button>
                </div>
            </div>
        </div>

    </div>
</div>
</template>

<script>
export default {
    name: 'CrawlView',
    data() {
        return {
            formData: [{
                site_name: '',
                url: '',
                category_id: null,
                selectors: {
                    name_selector: '',
                    price_selector: '',
                    link_selector: '',
                    image_selector: ''
                }
            }],
            statusLog: [],
            crawlStatus: ''
        };
    },
    methods: {
        async submitCrawlForm() {
            try {
                this.statusLog = []; // Clear previous logs
                const invalidEntries = this.formData.filter(data => !data.site_name || !data.url || !data.category_id);
                if (invalidEntries.length) {
                    this.statusLog.push('Vui lòng điền đầy đủ thông tin cho tất cả các mục.');
                    return;
                }
                this.crawlStatus = 'loading'
                const requests = this.formData.map(data => {
                    return this.axios.post('http://localhost:5000/crawl', data)
                        .then(response => response.data)
                        .catch(error => ({
                            error: error.message
                        }));
                });

                const results = await Promise.all(requests);
                this.statusLog = results;
                this.crawlStatus = 'success';
                console.log('Status Log:', this.statusLog);
            } catch (error) {
                this.crawlStatus = 'error'
                console.error('Error:', error);
                this.statusLog = [{
                    error: error.message
                }];
            }
        },
        addForm() {
            this.formData.push({
                site_name: '',
                url: '',
                category_id: null,
                selectors: {
                    name_selector: '',
                    price_selector: '',
                    link_selector: '',
                    image_selector: ''
                }
            });
        },
        removeForm(index) {
            this.formData.splice(index, 1);
        },
        async saveCrawledData() {
            try {
                // Log dữ liệu hiện tại trong statusLog
                console.log('Current statusLog:', this.statusLog);

                // Giả sử statusLog[0] là mảng chứa sản phẩm
                const products = this.statusLog[0] || [];

                // Chuẩn bị dữ liệu để gửi
                const productsToSave = products.map(product => ({
                    product_name: product.product_name || '', // Lấy đúng tên thuộc tính
                    product_price: product.product_price || '', // Lấy đúng tên thuộc tính
                    product_link: product.product_link || '', // Lấy đúng tên thuộc tính
                    product_image: product.product_image || '' // Lấy đúng tên thuộc tính
                })).filter(product => product.product_name); // Lọc bỏ sản phẩm không có tên

                // Gửi dữ liệu đến API
                const response = await this.axios.post('http://localhost:5000/add_products', {
                    products: productsToSave,
                    category_id: this.formData[0].category_id,
                    site_name: this.formData[0].site_name
                });

                if (response.data.status === 'success') {
                    this.statusLog.push('Dữ liệu đã được lưu thành công!');
                } else {
                    this.statusLog.push('Lưu dữ liệu thất bại. Phản hồi: ' + JSON.stringify(response.data));
                }
            } catch (error) {
                console.error('Error:', error);
                this.statusLog.push(`Lỗi khi lưu dữ liệu: ${error.message}`);
            }
        },
        toggleEdit(index) {
            this.statusLog[0][index].isEditing = !this.statusLog[0][index].isEditing;
        },
        deleteProduct(index) {
            this.statusLog[0].splice(index, 1); // Xóa sản phẩm khỏi danh sách
        },

    }
};
</script>

<style scoped>
.container {
    margin-top: 20px;
}

.card {

    margin-bottom: 20px;
}

.card-header {
    background-color: #2596be;
    padding: 5px;
}

.card-body {
    background-color: rgb(255, 255, 255);
    padding: 20px;
}

.pre {
    white-space: pre-wrap;
    /* Preserve whitespace and line breaks */
    background-color: #f5f5f5;
    padding: 10px;
    border-radius: 5px;
    overflow: auto;
    /* Enable scrolling */
}
</style>
