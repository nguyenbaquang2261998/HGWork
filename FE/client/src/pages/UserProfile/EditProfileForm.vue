<template>
  <form v-on:submit.prevent="submitForm">
    <md-card>
      <md-card-header :data-background-color="dataBackgroundColor">
        <h4 v-if="form.id == 0" class="title">Tạo dự án</h4>
        <h4 v-if="form.id > 0" class="title">Cập nhật dự án</h4>
        <p class="category">Nhập thông tin dự án</p>
      </md-card-header>

      <md-card-content>
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Tên dự án</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" id="name" v-model="form.name"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Code</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" id="code" v-model="form.code" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-25">
            <md-field>
              <label for="status">Trạng thái</label>
              <md-select required v-model="form.status" name="status" id="status">
                <md-option value="0">Active</md-option>
                <md-option value="1">InActive</md-option>
              </md-select>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-25">
            <md-field>
              <label for="priority">Độ ưu tiên</label>
              <md-select required v-model="form.priority" name="priority" id="priority">
                <md-option value="0">Thấp</md-option>
                <md-option value="1">Trung bình</md-option>
                <md-option value="2">Cao</md-option>
                <md-option value="3">Quan trọng</md-option>
              </md-select>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Mô tả</label>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" id="description" v-model="form.description" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày bắt đầu</p>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" id="startDate" v-model="form.startDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày kết thúc</p>
              <md-input required oninvalid="this.setCustomValidity('Vui lòng điền đầy đủ thông tin')" oninput="setCustomValidity('')" id="endDate" v-model="form.endDate" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-size-100 text-right">
            <md-button v-if="form.id == 0" type="submit" class="md-raised md-success">Tạo dự án</md-button>
            <md-button v-if="form.id > 0" type="submit" class="md-raised md-success">Cập nhật dự án</md-button>
          </div>
        </div>
      </md-card-content>
    </md-card>
  </form>
</template>
<script>
import axios from 'axios';
export default {
  name: "edit-profile-form",
  props: {
    dataBackgroundColor: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      form: {
        id: 0,
        name: '',
        code: '',
        status: 0,
        description: '',
        startDate: new Date(),
        endDate: new Date(),
        priority: 0
      }
    }
  },
  created() {
    const param = this.$route.params.id;
    if (typeof(param) != "undefined") {
      axios.get(`http://localhost:8080/project/detail/` + param)
        .then(response => {
          this.form.id = response.data.data.id;
          this.form.name = response.data.data.name;
          this.form.code = response.data.data.code;
          this.form.status = response.data.data.status;
          this.form.description = response.data.data.description;
          this.form.priority = response.data.data.priority;
          this.form.startDate = this.formatDate(response.data.data.startDate);
          this.form.endDate = this.formatDate(response.data.data.endDate);
        })
        .catch(e => {
          console.log("error");
        })
    }
  },
  // Gửi request lên server khi mà postPost() được gọi
  methods: {
    submitForm() {
      if(this.form.id > 0)
      {
        axios.post('http://localhost:8080/project/update', this.form)
        .then((res) => {
          if (res.status == 200) {
            location.href = "http://localhost:8080/#/listproject";
          }
          else {
            alert('Đã có lỗi xảy ra!');
          }
        })
        .catch((error) => {
          alert('Đã có lỗi xảy ra!');
        }).finally(() => {
          //Perform action in always
        });
      }
      else
      {
        axios.post('http://localhost:8080/project/create', this.form)
        .then((res) => {
          if (res.status == 200) {
            location.href = "http://localhost:8080/#/listproject";
          }
          else {
            alert('Đã có lỗi xảy ra!');
          }
        })
        .catch((error) => {
          alert('Đã có lỗi xảy ra!');
        }).finally(() => {
          //Perform action in always
        });
      }
    },
    formatDate(input) {
      var datePart = input.match(/\d+/g),
        year = datePart[0], // get only two digits
        month = datePart[1], day = datePart[2];

      return year + '-' + month + '-' + day;
    }
  },

};
</script>
