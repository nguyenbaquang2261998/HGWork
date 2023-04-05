<template>
  <form>
    <md-card>
      <md-card-header data-background-color="green">
        <h4 class="title">Tạo công việc </h4>
        <p class="category">Nhập thông tin công việc</p>
      </md-card-header>

      <md-card-content>
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-20">
            <div class="md-layout-item">
              <md-field>
                <label for="font">Dự án</label>
                <md-select v-model="font" name="project" id="project">
                  <md-option value="arial">Arial</md-option>
                  <md-option value="calibri">Calibri</md-option>
                  <md-option value="cambria">Cambria</md-option>
                  <md-option value="comic-sans">Comic Sans</md-option>
                  <md-option value="consolas">Consolas</md-option>
                  <md-option value="courier">Courier</md-option>
                  <md-option value="droid-sans">Droid Sans</md-option>
                  <md-option value="georgia">Georgia</md-option>
                  <md-option value="helvetica">Helvetica</md-option>
                  <md-option value="impact">Impact</md-option>
                  <md-option value="roboto">Roboto</md-option>
                  <md-option value="segoe-ui">Segoe UI</md-option>
                  <md-option value="times-new-roman">Times New Roman</md-option>
                  <md-option value="ubuntu">Ubuntu</md-option>
                  <md-option value="verdana">Verdana</md-option>
                </md-select>
              </md-field>
            </div>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-80">
            <md-field>
              <label>Tên công việc</label>
              <md-input v-model="username"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Code</label>
              <md-input v-model="username" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Trạng thái</label>
              <md-input v-model="address" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Mô tả</label>
              <md-input v-model="emailadress" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày bắt đầu</p>
              <md-input v-model="lastname" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <p style="margin-top: 8px; margin-right: 100px;">Ngày kết thúc</p>
              <md-input v-model="address" type="date"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-20">
            <md-field>
              <label for="font">Người nhận</label>
              <md-select v-model="font" name="font" id="font">
                <md-option value="arial">Arial</md-option>
                <md-option value="calibri">Calibri</md-option>
                <md-option value="cambria">Cambria</md-option>
                <md-option value="comic-sans">Comic Sans</md-option>
                <md-option value="consolas">Consolas</md-option>
                <md-option value="courier">Courier</md-option>
                <md-option value="droid-sans">Droid Sans</md-option>
                <md-option value="georgia">Georgia</md-option>
                <md-option value="helvetica">Helvetica</md-option>
                <md-option value="impact">Impact</md-option>
                <md-option value="roboto">Roboto</md-option>
                <md-option value="segoe-ui">Segoe UI</md-option>
                <md-option value="times-new-roman">Times New Roman</md-option>
                <md-option value="ubuntu">Ubuntu</md-option>
                <md-option value="verdana">Verdana</md-option>
              </md-select>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-80" style="margin-top: 40px">
            <label>Đã bàn giao <md-input v-model="firstname" type="checkbox"></md-input></label>
          </div>
          <div class="md-layout-item md-size-100 text-right">
            <md-button class="md-raised md-success">Tạo công việc</md-button>
          </div>
        </div>
      </md-card-content>
    </md-card>
  </form>
</template>
<script>
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
      username: null,
      disabled: null,
      emailadress: null,
      lastname: null,
      firstname: null,
      address: null,
      city: null,
      country: null,
      code: null,
      aboutme:
        "Lamborghini Mercy, Your chick she so thirsty, I'm in that two seat Lambo.",
    };
  },
};
</script>
<style></style>
