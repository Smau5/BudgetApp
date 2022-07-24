import { useQuery } from "@tanstack/react-query";
import listCategories from "../http/categories/list";
import { Category } from "../http/dto/category";
import { useEffect, useLayoutEffect, useRef, useState } from "react";
import { useCombobox, UseComboboxStateChange } from "downshift";
import { Box, Input, Text, useDimensions } from "@chakra-ui/react";

interface Props {
  initialSelectedId?: string;
}
const CategoryCombobox = ({ initialSelectedId }: Props) => {
  const categoriesQuery = useQuery(["categories"], listCategories);
  const categoriesList = categoriesQuery?.data?.data ?? [];
  const [items, setItems] = useState(categoriesList ?? []);
  const elementRef = useRef(null);
  const dimensions = useDimensions(elementRef, true);
  const {
    isOpen,
    getToggleButtonProps,
    getLabelProps,
    getMenuProps,
    getInputProps,
    getComboboxProps,
    highlightedIndex,
    getItemProps,
    selectedItem,
    openMenu,
    selectItem,
    setInputValue,
  } = useCombobox({
    onInputValueChange({ inputValue }) {
      setItems(categoriesList.filter(getCategoryFilter(inputValue)));
    },
    items,
    itemToString(item) {
      return item ? item.name : "";
    },
    onIsOpenChange(changes: UseComboboxStateChange<Category>) {
      if (changes.type === "__input_blur__") {
        setInputValue(changes.selectedItem?.name ?? "");
      }
      setItems(categoriesList);
    },
    defaultHighlightedIndex: 0,
  });

  useEffect(() => {
    if (categoriesList.length > 0 && initialSelectedId) {
      const selectedCategory = categoriesList.find(
        (c) => c.id == initialSelectedId
      );
      if (selectedCategory) {
        selectItem(selectedCategory);
      }
    }
  }, [initialSelectedId, categoriesList]);

  function getCategoryFilter(inputValue?: string) {
    return function categoryFilter(category: Category) {
      return !inputValue || category.name.toLowerCase().includes(inputValue);
    };
  }

  return (
    <>
      <Box {...getComboboxProps({ ref: elementRef })}>
        <Input
          size="sm"
          height="30px"
          border="0px"
          onClick={openMenu}
          onFocus={(event) => {
            event.target.select();
          }}
          {...getInputProps()}
        />
      </Box>
      <Box
        position={"absolute"}
        shadow={"md"}
        maxH="80px"
        overflowY={"auto"}
        w={dimensions?.borderBox.width ?? "50px"}
        background={"white"}
        zIndex={"1000"}
        {...getMenuProps()}
      >
        {isOpen &&
          items.map((item, index) => (
            <Box
              key={item.id}
              backgroundColor={highlightedIndex === index ? "#f3fcff" : "white"}
              {...getItemProps({ item, index })}
            >
              <Text>{item.name}</Text>
            </Box>
          ))}
      </Box>
    </>
  );
};

export default CategoryCombobox;
