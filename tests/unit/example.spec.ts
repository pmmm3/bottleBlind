import HomePage from "@/views/HomePage.vue";
import { mount } from "@vue/test-utils";
import { describe, expect, test } from "vitest";

describe("HomePage.vue", () => {
	test("renders home vue", () => {
		const wrapper = mount(HomePage);
		expect(wrapper.text()).toMatch("Ready to create an app?");
	});
});
